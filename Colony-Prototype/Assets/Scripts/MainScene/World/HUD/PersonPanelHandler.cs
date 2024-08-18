using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonPanelHandler : MonoBehaviour {

    public GameObject person;
    private PersonStats personStats;

    private TMP_Text nameLabel;
    void Start() {
        personStats = person.GetComponent<PersonStats>();
        nameLabel = GetComponentInChildren<TMP_Text>();
        nameLabel.text = personStats.personName;
    }

    void Update() {}

    public void OnSelect() {
        Debug.Log("Click on person " + personStats.personName);
    }
}
