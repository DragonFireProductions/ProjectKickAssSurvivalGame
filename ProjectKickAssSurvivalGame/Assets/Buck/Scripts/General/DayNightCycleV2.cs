﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycleV2 : MonoBehaviour
{
    [SerializeField]
    Light sun;

    [SerializeField]
    float secondsInFullDay = 120f;

    [Range(0, 1)]
    [SerializeField]
    float currentTimeOfDay = 0;

    float timeMultiplier = 1f;
    float sunIntialIntensity;

    int daysPassed;

	// Use this for initialization
	void Start ()
    {
        sunIntialIntensity = sun.intensity;
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
            daysPassed++;
        }
	}

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1f;

        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }

        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }

        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1/ 0.02f)));
        }

        sun.intensity = sunIntialIntensity * intensityMultiplier;
    }
}
