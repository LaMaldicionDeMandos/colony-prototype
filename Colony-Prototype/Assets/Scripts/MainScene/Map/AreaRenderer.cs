using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AreaRenderer : MonoBehaviour {
    public Tilemap tilemap;
    
    [SerializeField]
    public Area[] areas;

    private bool setted = false;

    void Start() {}

    // Update is called once per frame
    void Update() {
        if (!setted) {
            foreach(Area area in areas) {
                for (int i = area.bl.x; i <= area.tr.x; i++) {
                    for (int j = area.bl.y; j <= area.tr.y; j++) {
                        tilemap.SetColor(new Vector3Int(i, j, 0), area.color);
                    }
                }
            }
            //setted = true;
        }
    }
}
