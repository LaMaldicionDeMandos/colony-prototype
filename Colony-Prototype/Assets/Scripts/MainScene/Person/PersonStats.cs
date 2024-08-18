using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStats : MonoBehaviour {
    public PersonSpec spec;
    void Start() {}

    void Update() {}

    public string personName {
        get => spec.name;
    }
}
