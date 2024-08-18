using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PersonName : MonoBehaviour {
    private RectTransform textRectTransform;
    private float initialFieldOfView;
    private Vector3 initialScale;

    private TMP_Text nameLabel;


    public float powerFactor = 1.25f;
    void Start() {
        initialFieldOfView = Camera.main.fieldOfView;
        textRectTransform = GetComponent<RectTransform>();
        initialScale = textRectTransform.localScale;
        nameLabel = GetComponent<TMP_Text>();
        string name = transform.parent.parent.GetComponent<PersonStats>().personName;
        nameLabel.text = name;
    }

    void Update() {
        float scaleFactor = Mathf.Pow(Camera.main.fieldOfView/initialFieldOfView, powerFactor);
        textRectTransform.localScale = initialScale * scaleFactor;
    }
}
