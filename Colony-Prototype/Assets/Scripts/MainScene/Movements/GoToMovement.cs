using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMovement : Mortal {
    private static int PRIMARY_MOUSE_BUTTON = 0;

    private Movement[] movementComponents;
    private Vector3 goTo;

    protected override void Start() {
        movementComponents = GetComponents<Movement>();
        goTo = transform.position;
    }

    void Update() {
        OnClick();
        GoTo();
    }

    private void OnClick() {
        if (Input.GetMouseButtonDown(PRIMARY_MOUSE_BUTTON)) {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z; // Asegúrate de ajustar la profundidad según lo necesites
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;
            Debug.Log("Click on " + worldPosition);
            goTo = worldPosition;
        }
    }

    private void GoTo() {
        float distance = Vector3.Distance(transform.position, goTo);
        if (distance < 0.01) transform.position = goTo;
        Vector3 direction = CalculateDirection();
        foreach (Movement component in movementComponents) {
            component.UpdateDirection(direction);
        }
    }

    private Vector3 CalculateDirection() {
        return (transform.position != goTo) ? Vector3.Normalize(goTo - transform.position) : Vector3.zero; 
    }

    public override void Sleep() {
        Debug.Log("Durmiendo");
        this.enabled = false;
    }
}
