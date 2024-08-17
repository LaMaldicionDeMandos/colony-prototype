using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom2 : MonoBehaviour {
    private static int MIN_LEVEL = 0;
    private static int MAX_LEVEL = 6;

    public int zoomLevel = 1;
    public float minZoom = 50f;
    public float deltaLevel = 10f;

    private Camera camera;

    void Start() {
        camera = GetComponent<Camera>();
    }

    void Update() {
        var scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
	    if (scrollWheelInput != 0) {
		    zoomLevel += Mathf.RoundToInt(scrollWheelInput * 10);
            zoomLevel = Mathf.Clamp(zoomLevel, MIN_LEVEL, MAX_LEVEL);
            Zoom();
        }
    }

    void Zoom() {
        camera.fieldOfView = minZoom + zoomLevel*deltaLevel;
    }
}

/*
Normal 60
Minimo 40
Maximo 120
0 -> 50
1 -> 60
6 -> 140
12
40 + 10L
0 -> 50
1 -> 60
6 -> 110
*/