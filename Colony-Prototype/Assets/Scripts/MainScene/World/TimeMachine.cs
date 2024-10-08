using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeMachine : MonoBehaviour {
    private static float UNIT = 1.0f;
    private static int MINUTE_IN_SECONDS = 60;
    private static int HOUR_IN_MINUTES = 60;
    private static int DAY_IN_HOURS = 24;

    private static int MONTH_IN_DAYS = 20;
    private static int YEAR_IN_MONTHS = 4;

    private static float PAUSE_SPEED = 0.0f;
    private static float X1_SPEED = 0.2f;
    private static float X2_SPEED = 2.0f;
    private static float X3_SPEED = 20.0f;
    private static float X4_SPEED = 100.0f;

    private static string[] FORMATTED_MONTH = new string[] { "Spring", "Summer", "Fall", "Winter"};

    private float currentSecondFraction;
    public int CurrentSecond;
    public int CurrentMinute;

    public int CurrentHour;

    public int CurrentDay = 0;

    public int CurrentMonth;

    public int CurrentYear = 0;

    [SerializeField]
    public GameObject Label;

    private TMP_Text labelText;

    void Start() {        
        labelText = Label.GetComponent<TMP_Text>();
        OnPause();
    }

    void Update() {
        printTime();
    }

    public void OnPause() {
        Time.timeScale = PAUSE_SPEED;
    }

    public void OnPlay() {
        Time.timeScale = X1_SPEED;
    }

    public void OnForward() {
        Time.timeScale = X2_SPEED;
    }

    public void OnForwardX2() {
        Time.timeScale = X3_SPEED;
    }

    public void OnForwardX3() {
        Time.timeScale = X4_SPEED;
    }

    private int UpdateTime(ref int time, int delta, int module) {
        time+= delta;
        if (time >= module) {
            time-= module;
            return 1;
        } else {
            return 0;
        }        
    }

    private int UpdateSecondsFranction(float dt) {
        currentSecondFraction+= dt;
        if (currentSecondFraction > UNIT) {
            int extra = Mathf.CeilToInt(currentSecondFraction - UNIT);
            currentSecondFraction-= extra;
            return extra;
        } else {
            return 0;
        }
    }

    private void CalculateNewTime() {
        int ds = UpdateSecondsFranction(Time.deltaTime*10);
        int dm = UpdateTime(ref CurrentSecond, ds, MINUTE_IN_SECONDS);
        int dh = UpdateTime(ref CurrentMinute, dm, HOUR_IN_MINUTES);
        int dd = UpdateTime(ref CurrentHour, dh, DAY_IN_HOURS);
        int dM = UpdateTime(ref CurrentDay, dd, MONTH_IN_DAYS);
        int dy = UpdateTime(ref CurrentMonth, dM, YEAR_IN_MONTHS);
        CurrentYear+= dy;
    }

    private void printTime() {
        CalculateNewTime();
        string formattedTime = $"{CurrentHour:D2}:{CurrentMinute:D2} Day {(CurrentDay + 1)}, {FormatMonth(CurrentMonth)} Year {(CurrentYear + 1)}";
        labelText.text = formattedTime;     
    }

    private string FormatMonth(int month) {
        return FORMATTED_MONTH[month];
    }
    
}
