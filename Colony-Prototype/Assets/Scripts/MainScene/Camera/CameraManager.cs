using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CameraManager : MonoBehaviour {

    private static int ZOOM_X_DELTA = 16;
    private int ZOOM_Y_DELTA = 9;

    private static int ZOOM_FACTOR = 5;

    private static int MIN_ZOOM_X = 240;
    private static int MIN_ZOOM_Y = 135;

    private static int MIN_LEVEL = 0;
    private static int MAX_LEVEL = 6;

    private static float VELOCITY_FACTOR = 0.025f;

    private PixelPerfectCamera pixelPerfectCamera;
    public int zoomLevel = 1;
    public float edgeSize = 10.0f;

    void Start() {
        pixelPerfectCamera = GetComponent<PixelPerfectCamera>();
        Zoom();
    }

    void Update() {
        var scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
	    if (scrollWheelInput != 0) {
		    zoomLevel += Mathf.RoundToInt(-scrollWheelInput * 10);
            zoomLevel = Mathf.Clamp(zoomLevel, MIN_LEVEL, MAX_LEVEL);
            Zoom();
        }
        UpdateMove();
    }

    void Zoom() {
        int zoomX = Mathf.FloorToInt(MIN_ZOOM_X + zoomLevel*ZOOM_FACTOR*ZOOM_X_DELTA);
        int zoomY = Mathf.FloorToInt(MIN_ZOOM_Y + zoomLevel*ZOOM_FACTOR*ZOOM_Y_DELTA);
        pixelPerfectCamera.refResolutionX = zoomX;
		pixelPerfectCamera.refResolutionY = zoomY;
    }

    private void UpdateMove() {
        float velocity = zoomLevel + 1;
        UpdateMoveByKeys(velocity);
        UpdateMoveByBorder(velocity);
    }

    private void MoveToLeft(float velocity) {
        transform.position+= new Vector3(-velocity*VELOCITY_FACTOR, 0, 0);
    }

    private void MoveToRight(float velocity) {
        transform.position+= new Vector3(velocity*VELOCITY_FACTOR, 0, 0);        
    }

    private void MoveToUp(float velocity) {
        transform.position+= new Vector3(0, velocity*VELOCITY_FACTOR, 0);
    }

    private void MoveToDown(float velocity) {
        transform.position+= new Vector3(0, -velocity*VELOCITY_FACTOR, 0);         
    }

    private void UpdateMoveByKeys(float velocity) {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            MoveToLeft(velocity);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            MoveToRight(velocity);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            MoveToUp(velocity);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            MoveToDown(velocity);
        }
    }

    private void UpdateMoveByBorder(float velocity) {
        if (Input.mousePosition.x >= Screen.width - edgeSize) {
            MoveToRight(velocity);
        }
        if (Input.mousePosition.x < edgeSize) {
            MoveToLeft(velocity);
        }
        if (Input.mousePosition.y < edgeSize) {
            MoveToDown(velocity);
        }
        if (Input.mousePosition.y >= Screen.height - edgeSize) {
            MoveToUp(velocity);
        }
    }
}
