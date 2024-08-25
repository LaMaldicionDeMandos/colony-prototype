using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class MapGenerationComponent : MonoBehaviour {
    private static string MAIN_GAME_SCENE = "MainScene"; 
    public GameObject mapGameObject;
    public MapGenerationConfig config;
    void Start() {}

    void Update() {}

    public void GenerateMap(int seed) {
        Map map = Map.BuildBySeed(seed, config);
        mapGameObject.GetComponent<MapSpecsManager>().map = map;
        string path = Application.persistentDataPath + "/saved";
        Debug.Log(path);
        string json = JsonConvert.SerializeObject(map, Formatting.Indented);
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/current.json", json);
        SceneManager.LoadScene(MAIN_GAME_SCENE);
    }
}
