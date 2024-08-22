using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpecsManager : MonoBehaviour {
    public static MapSpecsManager Instance;
    private Map _map;

    public Map map {
        get => _map;
        set {
            _map = value;
            Debug.Log("Width: " + _map.width + ", Heigth: " + _map.heigth);
            for( int i = 0; i < _map.width; i++) {
                Debug.Log("-------------------------------------");
                for( int j = 0; j < _map.heigth; j++) {
                    Debug.Log(_map.terrainMatrix[i, j].terrainName);
                }
            }
        }
    }

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    void Start() {}

    void Update() {}
}
