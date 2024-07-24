using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour {
    private Tilemap tilemap;
    private TileBase[,] map;
    public TileBase[] tile;

    void Start() {
        map = MakeMap();
        tilemap = GetComponent<Tilemap>();
        for(int x = -5; x < 6; x++) {
            for(int y = -5; y < 6; y++) {
                tilemap.SetTile(new Vector3Int(x, y, 0), map[x + 5, y + 5]);    
            }
        }
    }

    void Update() {
        
    }

    private TileBase[,] MakeMap() {
        int[,] bases = new int[,] {
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
        TileBase[,] tiles = new TileBase[11, 11];
        for(int i = 0; i < 11; i++) {
            for(int j = 0; j < 11; j++) {
                tiles[i, j] = tile[bases[i, j]];
            }
        }
        return tiles;
    }
}
