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

    public double StonePercent;
    public double MountainPercent;
    public double RockPercent;
    public double BushPercent;
    public double TreePercent;

    private System.Random rng;

    private Tilemap tilemap;
    private TileBase[,] map;
    public TileBase[] tile;

    public GameObject[] mapElements;

    private List<GameObject> gameObjects;

    void Start() {
        int seed = UnityEngine.Random.Range(0, 10000);
        rng = new System.Random(seed);
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
        MakeThings();
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

    private void MakeThings() {
        gameObjects = new List<GameObject>();
        for(int x = -MapWidth/2; x < (MapWidth - MapWidth/2); x++) {
            for(int y = -MapHeigth/2; y < (MapHeigth - MapHeigth/2); y++) {
                TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
                AddThingToTile(tile, x, y);
            }
        }
    }

    private void AddThingToTile(TileBase tile, int x, int y) {
        if (CanAddMountain(tile)) TryToAddMountain(tile, x, y);
        if (CanAddRock(tile)) TryToAddRock(tile, x, y);
        if (CanAddBush(tile)) TryToAddBush(tile, x, y);
        if (CanAddStone(tile)) TryToAddStone(tile, x, y);
        if (CanAddTree(tile)) TryToAddTree(tile, x, y);
    }

    private bool CanAddMountain(TileBase tile) {
        return "Montain_Tile_Rule" == tile.name;
    }

    private bool CanAddRock(TileBase tile) {
        return "Sand_Tile_Rule" == tile.name || "Grass_Tile_Rule" == tile.name;
    }

    private bool CanAddBush(TileBase tile) {
        return "Grass_Tile_Rule" == tile.name;
    }

    private bool CanAddStone(TileBase tile) {
        return "Sand_Tile_Rule" == tile.name;
    }

    private bool CanAddTree(TileBase tile) {
        return "Grass_Tile_Rule" == tile.name;
    }

    private void TryToAddMountain(TileBase tile, int x, int y) {
        double r = rng.NextDouble();
        if (r < MountainPercent) {
            gameObjects.Add(Instantiate(mapElements[0], new Vector3(x, y, Z_PROSITION), Quaternion.identity));
        }
    }

    private void TryToAddRock(TileBase tile, int x, int y) {
        double r = rng.NextDouble();
        if (r < RockPercent) {
            gameObjects.Add(Instantiate(mapElements[1], new Vector3(x, y, Z_PROSITION), Quaternion.identity));
        }
    }

    private void TryToAddBush(TileBase tile, int x, int y) {
        double r = rng.NextDouble();
        if (r < BushPercent) {
            gameObjects.Add(Instantiate(mapElements[2], new Vector3(x, y, Z_PROSITION), Quaternion.identity));
        }
    }

    private void TryToAddStone(TileBase tile, int x, int y) {
        double r = rng.NextDouble();
        if (r < StonePercent) {
            gameObjects.Add(Instantiate(mapElements[3], new Vector3(x, y, Z_PROSITION), Quaternion.identity));
        }
    }

    private void TryToAddTree(TileBase tile, int x, int y) {
        double r = rng.NextDouble();
        if (r < TreePercent) {
            gameObjects.Add(Instantiate(mapElements[4], new Vector3(x, y, Z_PROSITION), Quaternion.identity));
        }
    }

}