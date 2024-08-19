using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PersonPanelHandler : MonoBehaviour, IPointerClickHandler {
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

    void OnDoubleClick() {
        Debug.Log("Double click  on person " + personStats.personName);
        Transform cameraTransform = Camera.main.transform;
        cameraTransform.position = new Vector3(person.transform.position.x, person.transform.position.y, cameraTransform.position.z);
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.clickCount == 1) {
            OnSelect();
        }
        if (eventData.clickCount == 2) {
            OnDoubleClick();
        }
    }
}
