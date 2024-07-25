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

    private static int[,] BASES = new int[,] {
            {3,3,3,0,0,0,0,0,0,0,0},
            {3,3,1,1,1,0,0,0,0,0,2},
            {3,3,3,0,1,1,0,0,0,2,1},
            {3,3,3,0,0,1,1,1,1,1,1},
            {3,3,0,0,0,0,1,1,1,1,1},
            {3,3,0,0,0,0,0,1,1,1,1},
            {3,0,0,0,0,0,0,0,2,2,2},
            {0,0,0,0,0,0,0,0,0,2,2},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };

    private static MapElement[] ELEMENTS = new MapElement[] { 
        //new MapElement(-5, -5, 0),
        //new MapElement(-5, -4, 0),
        //new MapElement(-5, -3, 0),
        //new MapElement(-4, -5, 0),
        //new MapElement(-4, -4, 0),
        //new MapElement(-3, -5, 0),
        //new MapElement(-3, -4, 0),
        //new MapElement(-3, -3, 0),
        //new MapElement(-2, -5, 0),
        //new MapElement(-2, -4, 0),
        //new MapElement(-2, -3, 0),
        //new MapElement(-1, -5, 0),
        //new MapElement(-1, -4, 0),
        //new MapElement(0, -5, 0),
        //new MapElement(0, -4, 0),
        //new MapElement(1, -5, 0),
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
        MakeMap();
        MakeThinks();
    }

    void Update() {
        
    }

    private void MakeMap() { 
        TileBase[,] tiles = new TileBase[MapWidth, MapHeigth];
        for(int i = 0; i < MapWidth; i++) {
            for(int j = 0; j < MapHeigth; j++) {
                float x = (float)i/MapWidth * NoiseScale;
                float y = (float)j/MapHeigth * NoiseScale;
                int terrainIndex = (int)Mathf.Floor(Mathf.PerlinNoise(x, y) * 4);
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

    private void MakeThinks() {
        gameObjects = new List<GameObject>();
        foreach(MapElement element in ELEMENTS) {
            gameObjects.Add(Instantiate(mapElements[element.elementIndex], new Vector3(element.x, element.y, Z_PROSITION), Quaternion.identity));
        }
    }
}