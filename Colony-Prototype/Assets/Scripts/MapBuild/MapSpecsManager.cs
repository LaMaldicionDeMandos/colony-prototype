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
