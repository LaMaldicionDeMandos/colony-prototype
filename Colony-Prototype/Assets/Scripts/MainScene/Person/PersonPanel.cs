using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPanel : MonoBehaviour {
    public GameObject personPanelPrefab;

    private List<GameObject> people = new List<GameObject>();
    void Start() {
        GameObject[] rootObjects = gameObject.scene.GetRootGameObjects();
        foreach(GameObject obj in rootObjects) {
            if (obj.TryGetComponent<PersonStats>(out PersonStats stats)) {
                people.Add(obj);
            }
        }
        for (int i = 0; i < people.Count; i++) {
            AddPerson(i, people[i], people.Count);
        }
    }

    void Update() {}

    private void AddPerson(int index, GameObject person, int size) {
        int first = -25*size;
        int x = first + 50*index + ((size + 1) % 2)*25;
        Debug.Log("Adding person " + person.name);
        GameObject personPanel = Instantiate(personPanelPrefab);       
        personPanel.transform.SetParent(transform);     
        RectTransform rect = personPanel.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(x, 0f);
    }
}
