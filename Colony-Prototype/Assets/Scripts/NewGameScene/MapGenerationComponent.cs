using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationComponent : MonoBehaviour {
    public GameObject map;
    public MapGenerationConfig config;
    void Start() {}

    void Update() {}

    public void GenerateMap(int seed) {
        Map map = Map.BuildBySeed(seed, config);

        Debug.Log("Width: " + map.width + ", Heigth: " + map.heigth);
        for( int i = 0; i < map.width; i++) {
            Debug.Log("-------------------------------------");
            for( int j = 0; j < map.heigth; j++) {
                Debug.Log(map.terrainMatrix[i, j].terrainName);
            }
        }

    }
}
