using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    // Editor Variables
    [Header("Rotation")]
    [SerializeField]
    float m_rate;
    [SerializeField]
    float m_day;
    [SerializeField]
    float m_night;

    // Variables
    Light m_light;
    bool  m_isNight;
    bool  m_canCycle;

	void Start () {
        // component retrieval
        m_light = GetComponent<Light>();

        // variable initialization
        m_canCycle = true;
        m_isNight  = false;
    }

    void Update () {
        if (Input.GetKey(KeyCode.A)) {
            m_canCycle = true;
            m_isNight = false;
        }

        if (m_canCycle) {
            m_light.transform.Rotate(Vector3.right, Time.deltaTime * m_rate);

            Vector3 euler = m_light.transform.eulerAngles;
            if (!m_isNight) {
                if (euler.x < 330.0f && euler.x > 325.0f) {
                    m_isNight = true;
                }
            }
            else {
                if (euler.x < 330.0f && euler.x > 325.0f) {
                    if (euler.y == 0.0f && euler.z == 0.0f) {
                        m_canCycle = false;
                    }
                }
            }
        }
    }

    // Accessors
    bool IsNight() {
        return m_isNight;
    }
}
