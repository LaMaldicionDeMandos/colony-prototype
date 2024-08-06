using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AreaRenderer : MonoBehaviour {
    public Tilemap tilemap;
    
    [SerializeField]
    public Area[] areas;

    private bool active = true;
    private bool shouldChange = true;

    void Start() {}

    void Update() {
        if (shouldChange) {
            foreach(Area area in areas) {
                for (int i = area.bl.x; i <= area.tr.x; i++) {
                    for (int j = area.bl.y; j <= area.tr.y; j++) {
                        if (active) tilemap.SetColor(new Vector3Int(i, j, 0), area.color);
                        else tilemap.SetColor(new Vector3Int(i, j, 0), Color.white);
                    }
                }
            }
            shouldChange = false;
        }
    }

    public void OnActiveAreas() {
        this.active = !active;
        this.shouldChange = true;
    }
}
