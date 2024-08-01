using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CameraZoom : MonoBehaviour {

    private static int ZOOM_X_DELTA = 16;
    private int ZOOM_Y_DELTA = 9;

    private static int ZOOM_FACTOR = 5;

    private static int MIN_ZOOM_X = 240;
    private static int MIN_ZOOM_Y = 135;

    private static int MIN_LEVEL = 0;
    private static int MAX_LEVEL = 6;

    private PixelPerfectCamera pixelPerfectCamera;
    public int zoomLevel = 1;
    void Start() {
        pixelPerfectCamera = GetComponent<PixelPerfectCamera>();
        Zoom();
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
        int zoomX = Mathf.FloorToInt(MIN_ZOOM_X + zoomLevel*ZOOM_FACTOR*ZOOM_X_DELTA);
        int zoomY = Mathf.FloorToInt(MIN_ZOOM_Y + zoomLevel*ZOOM_FACTOR*ZOOM_Y_DELTA);
        pixelPerfectCamera.refResolutionX = zoomX;
		pixelPerfectCamera.refResolutionY = zoomY;
    }
}
