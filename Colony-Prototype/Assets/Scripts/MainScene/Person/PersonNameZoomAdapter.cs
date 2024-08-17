using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonNameZoomAdapter : MonoBehaviour {
    private RectTransform textRectTransform;
    private float initialFieldOfView;
    private Vector3 initialScale;

    public float powerFactor = 1.25f;
    void Start() {
        initialFieldOfView = Camera.main.fieldOfView;
        textRectTransform = GetComponent<RectTransform>();
        initialScale = textRectTransform.localScale;
    }

    void Update() {
        float scaleFactor = Mathf.Pow(Camera.main.fieldOfView/initialFieldOfView, powerFactor);
        textRectTransform.localScale = initialScale * scaleFactor;
    }
}
