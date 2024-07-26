using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeMachine : MonoBehaviour {
    private static float UNIT = 1.0f;
    private static int MINUTE_IN_SECONDS = 60;
    private static int HOUR_IN_MINUTES = 60;

    private float currentSecondsFraction;
    private int currentSeconds;
    private int currentMinutes;

    [SerializeField]
    public GameObject Label;

    private TMP_Text labelText;

    void Start() {        
        labelText = Label.GetComponent<TMP_Text>();
        labelText.text = "TIME!!";
    }

    void Update() {
        int ds = UpdateSecondsFranction(Time.deltaTime);
        int dm = UpdateSeconds(ds);
        int dh = UpdateMinutes(dm);
        Debug.Log("F: " + currentSecondsFraction + " -- s: " + currentSeconds + " -- m: " + currentMinutes + " -- h: " + dh);
    }

    private int UpdateSecondsFranction(float dt) {
        currentSecondsFraction+= dt;
        if (currentSecondsFraction > UNIT) {
            currentSecondsFraction-= UNIT;
            return 1;
        } else {
            return 0;
        }
    }

    private int UpdateSeconds(int ds) {
        currentSeconds+= ds;
        if (currentSeconds >= MINUTE_IN_SECONDS) {
            currentSeconds-= MINUTE_IN_SECONDS;
            return 1;
        } else {
            return 0;
        }
    }

    private int UpdateMinutes(int dm) {
        currentMinutes+= dm;
        if (currentMinutes >= HOUR_IN_MINUTES) {
            currentMinutes-= HOUR_IN_MINUTES;
            return 1;
        } else {
            return 0;
        }
    }
    
}
