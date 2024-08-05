using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MousePositionRender : MonoBehaviour {
    private TMP_Text labelText;
    void Start() {
         labelText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 mousePosition =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        labelText.text = $"({Mathf.FloorToInt(mousePosition.x)}, {Mathf.FloorToInt(mousePosition.y)})";    
    }
}
