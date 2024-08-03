using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveManager : MonoBehaviour {
    public int count;

    void Start() {}

    void Update(){}

    public void OnSave() {
        Debug.Log("Save from Save Manager");
        string jsonData = JsonUtility.ToJson(this);
        Debug.Log("Save data: " + jsonData);
    }
}
