using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapGenerationComponent : MonoBehaviour {
    private static string MAIN_GAME_SCENE = "MainScene"; 
    public GameObject mapGameObject;
    public MapGenerationConfig config;
    void Start() {}

    void Update() {}

    public void GenerateMap(int seed) {
        Map map = Map.BuildBySeed(seed, config);
        mapGameObject.GetComponent<MapSpecsManager>().map = map;
        SceneManager.LoadScene(MAIN_GAME_SCENE);
    }
}
