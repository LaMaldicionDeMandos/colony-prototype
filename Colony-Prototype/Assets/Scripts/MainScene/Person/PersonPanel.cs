using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPanel : MonoBehaviour {

    private List<GameObject> people = new List<GameObject>();
    void Start() {
        GameObject[] rootObjects = gameObject.scene.GetRootGameObjects();
        foreach(GameObject obj in rootObjects) {
            if (obj.TryGetComponent<PersonStats>(out PersonStats stats)) {
                people.Add(obj);
                AddPerson(obj);
            }
        }
    }

    void Update() {}

    private void AddPerson(GameObject person) {
        Debug.Log("Adding person " + person.name);
    }
}
