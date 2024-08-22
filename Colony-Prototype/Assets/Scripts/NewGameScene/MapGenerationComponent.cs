using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationComponent : MonoBehaviour {
    public GameObject mapGameObject;
    public MapGenerationConfig config;
    void Start() {}

    void Update() {}

    public void GenerateMap(int seed) {
        Map map = Map.BuildBySeed(seed, config);
        mapGameObject.GetComponent<MapSpecsManager>().map = map;
    }
}
