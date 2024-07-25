using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public record MapElement(
    int x,
    int y,
    int elementIndex);

public class MapGenerator : MonoBehaviour {
    private static float Z_PROSITION = 0.0f;
    public int MapWidth;
    public int MapHeigth;
    public float NoiseScale;

    public float WaterFactor;
    public float SandFactor;
    public float GrassFactor;
    public float MoutainFactor;

    private System.Random rng;

    private static MapElement[] ELEMENTS = new MapElement[] { 
        new MapElement(-1, -3, 1),
        new MapElement(0, -3, 1),
        new MapElement(1, -4, 1),
        new MapElement(1, 2, 2),
        new MapElement(2, 3, 2),
        new MapElement(3, 4, 2),
        new MapElement(3, 5, 2),
        new MapElement(3, 3, 3),
        new MapElement(2, 2, 3),
        new MapElement(1, -3, 3),
        new MapElement(-1, -2, 3),
        new MapElement(5, -5, 4),        
        new MapElement(4, -5, 4),
        new MapElement(3, -5, 4),                
        new MapElement(5, -4, 4),
        new MapElement(4, -4, 4),
        new MapElement(5, -3, 4),
        new MapElement(4, -3, 4),
        new MapElement(3, -3, 4),
        new MapElement(2, -3, 4),
        new MapElement(5, -2, 4),
        new MapElement(4, -2, 4),
        new MapElement(3, -2, 4),
        new MapElement(2, -2, 4)               
    };

    private Tilemap tilemap;
    private TileBase[,] map;
    public TileBase[] tile;

    public GameObject[] mapElements;

    private List<GameObject> gameObjects;

    void Start() {
        int seed = UnityEngine.Random.Range(0, 10000);
        float sum = WaterFactor + SandFactor + GrassFactor + MoutainFactor;
        float waterLimit = WaterFactor/sum;
        float sandLimit = waterLimit + SandFactor/sum;
        float grassLimit = sandLimit + GrassFactor/sum;
        float mountainLimit = grassLimit + MoutainFactor/sum;
        Tuple<float, float>[] ranges = new Tuple<float, float>[] {
            new Tuple<float, float>(0.0f, waterLimit),
            new Tuple<float, float>(waterLimit, sandLimit),
            new Tuple<float, float>(sandLimit, grassLimit),
            new Tuple<float, float>(grassLimit, mountainLimit)
        };
        MakeMap(seed, ranges);
 //       MakeThinks();
    }

    void Update() {
        
    }

    private float[,] GenerateNoiseMap(int mapWidth, int mapHeigth, float elevationScale, int seed) {
        float[,] noiseMap = new float[mapWidth, mapHeigth];
        System.Random rand = new System.Random(seed);

        float offsetX = rand.Next(-100000, 100000);
        float offsetY = rand.Next(-100000, 100000);

        for (int i = 0; i < mapWidth; i++) {
            for (int j = 0; j < mapHeigth; j++) {
                float x = (float)i / mapWidth * elevationScale + offsetX;
                float y = (float)j / mapHeigth * elevationScale + offsetY;
                noiseMap[i, j] = Mathf.PerlinNoise(x, y);
            }
        }

        return noiseMap;
    }

    private void MakeMap(int seed, Tuple<float, float>[] terrainRanges) {
        float[,] noiseMap = GenerateNoiseMap(MapWidth, MapHeigth, NoiseScale, seed); 
        TileBase[,] tiles = new TileBase[MapWidth, MapHeigth];
        for(int i = 0; i < MapWidth; i++) {
            for(int j = 0; j < MapHeigth; j++) {
                int terrainIndex = GetTerrainIndex(Mathf.Clamp(noiseMap[i, j], 0.0f, 1.0f), terrainRanges);
                tiles[i, j] = tile[terrainIndex];
            }
        }
        tilemap = GetComponent<Tilemap>();
        for(int x = -MapWidth/2; x < (MapWidth - MapWidth/2); x++) {
            for(int y = -MapHeigth/2; y < (MapHeigth - MapHeigth/2); y++) {
                tilemap.SetTile(new Vector3Int(x, y, 0), tiles[x + MapWidth/2, y + MapHeigth/2]);    
            }
        }
    }

    private int GetTerrainIndex(float noise, Tuple<float, float>[] ranges) {
        for(int i = 0; i < 4; i++) {
            if (noise <= ranges[i].Item2) return i;
        }
        return 3;
    }

    private void MakeThinks() {
        gameObjects = new List<GameObject>();
        foreach(MapElement element in ELEMENTS) {
            gameObjects.Add(Instantiate(mapElements[element.elementIndex], new Vector3(element.x, element.y, Z_PROSITION), Quaternion.identity));
        }
    }
}