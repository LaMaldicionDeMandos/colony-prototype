using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MapGenerator : MonoBehaviour {
    private static float Z_PROSITION = 0.0f;

    public double StonePercent;
    public double MountainPercent;
    public double RockPercent;
    public double BushPercent;
    public double TreePercent;

    private System.Random rng;

    private Tilemap tilemap;
    private TileBase[,] map;
    public TileBase[] tile;

    [SerializeField]
    public ElementSpawnSpec[] ElementSpecs;

    public GameObject[] mapElements;

    public ItemSpec[] itemsSpecs;

    private List<GameObject> gameObjects;

    private MapSpecsManager mapSpecManager;

    void Start() {
        mapSpecManager = GameObject.FindWithTag("MapSpec").GetComponent<MapSpecsManager>();
        Map map = mapSpecManager.map;
        MakeMap(map);
        //MakeThings();
    
    }

    void Update() {
        
    }


    private async void MakeMap(Map map) { 
        TileBase[,] tiles = new TileBase[map.width, map.heigth];
        ISet<AsyncOperationHandle<TileBase>> loadTasks = LoadTiles(map);
        IEnumerable<Task<TileBase>> tasks = loadTasks.Select(h => h.Task);
        Dictionary<string, TileBase> tileBases = new Dictionary<string, TileBase>();
        foreach (Task<TileBase> task in tasks) {
            TileBase tile = await task;
            tileBases.Add(tile.name, tile);
        }
        for(int i = 0; i < map.width; i++) {
            for(int j = 0; j < map.heigth; j++) {
                Debug.Log("Creating Tile from: " + map.terrainMatrix[i,j].terrainName);
                tiles[i, j] = tileBases[map.terrainMatrix[i,j].tileRuleName];
            }
        }

        tilemap = GetComponent<Tilemap>();
        for(int x = -map.width/2; x < (map.width - map.width/2); x++) {
            for(int y = -map.heigth/2; y < (map.heigth - map.heigth/2); y++) {
                tilemap.SetTile(new Vector3Int(x, y, 0), tiles[x + map.width/2, y + map.heigth/2]);   
            }
        }
    }



    private ISet<string> GetTileTypes(Map map) {
        ISet<string> tileTypes = new HashSet<string>();
        for(int i = 0; i < map.width; i++) {
            for(int j = 0; j < map.heigth; j++) {
                tileTypes.Add(map.terrainMatrix[i,j].tileRuleName);
            }
        }
        return tileTypes;
    }

    private ISet<AsyncOperationHandle<TileBase>> LoadTiles(Map map) {
        ISet<string> tileTypes = GetTileTypes(map);
        ISet<AsyncOperationHandle<TileBase>> loadTasks = tileTypes.Select(typeName => Addressables.LoadAssetAsync<TileBase>(typeName)).ToHashSet();
        return loadTasks;
    }


    private int GetTerrainIndex(float noise, Tuple<float, float>[] ranges) {
        for(int i = 0; i < 4; i++) {
            if (noise <= ranges[i].Item2) return i;
        }
        return 3;
    }

    private void MakeThings() {
        /*
        gameObjects = new List<GameObject>();
        for(int x = -MapWidth/2; x < (MapWidth - MapWidth/2); x++) {
            for(int y = -MapHeigth/2; y < (MapHeigth - MapHeigth/2); y++) {
                TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
                AddThingToTile(tile, x, y);
            }
        }
        */
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