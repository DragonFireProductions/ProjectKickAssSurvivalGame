using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  Documentation
//
//
//      Variables (Time):
//          Hour = hour of day in game, according to position of sun
//          Minute = minute of day in game, according to position of sun
//          Meridiem = Morning/Evening
//          
//      Variables (Conversion):
//          Minute to Second = conversion of game time minute to real time second
//              e.g.    60.0f = 60 minutes of game time to 1 second of real time    (fast)
//              e.g.    1.0f  = 1 minute of game time to 1 second of real time      (very slow)
//
//      Variables (Attributes):
//          Can Cycle = enabling of the clock. If the clock needs to be paused, just change the cycle state.
//
//
//      Functionality:
//          This is a functional day night cycle. It dynamically changes the time of day throughout the life of the program.
//          Attach this to a directional light to rotate it as time elapses.
//
//
//  Author: Jason Dagger
//  Date: 5/9/2018
//  Last Edit: 5/9/2018
//

public class DayNightCycle : MonoBehaviour {

    public enum Meridiem {
          AM
        , PM
    }


    [Header("Time")]
    [SerializeField]
    [Range(1, 12)]
    int m_hour = 6;
    [SerializeField]
    [Range(0, 59)]
    int m_minute = 0;
    [SerializeField]
    Meridiem m_meridiem = Meridiem.AM;

    [Header("Conversion")]
    [SerializeField]
    float m_minuteToSecond = 60.0f;

    [Header("Attributes")]
    [SerializeField]
    bool m_canCycle = true;


    float m_elapsedMS = 0.0f;


	void Start () {
        AdjustMeridiem();
    }

    void Update() {
        if (!m_canCycle) {
            return;
        }

        m_elapsedMS += Time.deltaTime * m_minuteToSecond;

        if (m_elapsedMS > 1.0f) {
            m_elapsedMS = 0.0f;

            m_minute += 1;   
            if (m_minute > 59) {
                m_minute = 0;

                m_hour += 1;
                if (m_hour > 12) {
                    m_hour = 1;

                    switch (m_meridiem) {
                        case Meridiem.AM: { 
                            m_meridiem = Meridiem.PM;
                            break;
                        }
                        case Meridiem.PM: {
                            m_meridiem = Meridiem.AM;
                            break;
                        }

                        default: {
                            break;
                        }
                    }
                }
            }

            AdjustMeridiem();
        }
    }

    // Mutators
    public void SetCycle(bool canCycle) {
        m_canCycle = canCycle;
    }
    public void SetHour(int hour) {
        m_hour = hour;

        if (m_hour > 12) {
            m_hour = 12;
        }
        else if (m_hour < 1) {
            m_hour = 1;
        }

        AdjustMeridiem();
    }
    public void SetMinute(int minute) {
        m_minute = minute;

        if (m_minute > 59) {
            m_minute = 59;
        }
        else if (m_minute < 0) {
            m_minute = 0;
        }

        AdjustMeridiem();
    }
    public void SetMeridiem(Meridiem meridiem) {
        m_meridiem = meridiem;
    }
    public void SetMinuteToSecond(float minuteToSecond) {
        m_minuteToSecond = minuteToSecond;
    }

    // Accessors
    public bool CanCycle() {
        return m_canCycle;
    }
    public int GetHour() {
        return m_hour;
    }
    public int GetMinute() {
        return m_minute;
    }
    public Meridiem GetMeridiem() {
        return m_meridiem;
    }
    public float GetMinuteToSecond() {
        return m_minuteToSecond;
    }


    void AdjustMeridiem() {
        switch (m_meridiem) {
            case Meridiem.AM: { 
                transform.eulerAngles = new Vector3(270 + m_hour * 15 + m_minute * 0.25f, 0, 0);
                break;
            }
            case Meridiem.PM: {
                transform.eulerAngles = new Vector3(90 + m_hour * 15 + m_minute * 0.25f, 0, 0);
                break;
            }

            default: {
                break;
            }
        }
    }
}


//if (m_canCycle) {
//    m_light.transform.Rotate(Vector3.right, Time.deltaTime * m_rate);
//
//    Vector3 euler = m_light.transform.eulerAngles;
//    if (!m_isNight) {
//        if (euler.x < 330.0f && euler.x > 325.0f) {
//            m_isNight = true;
//        }
//    }
//    else {
//        if (euler.x < 330.0f && euler.x > 325.0f) {
//            if (euler.y == 0.0f && euler.z == 0.0f) {
//                m_canCycle = false;
//            }
//        }
//    }
//}