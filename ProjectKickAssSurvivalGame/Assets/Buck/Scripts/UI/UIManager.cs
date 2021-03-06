﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> dynamicUI = new List<GameObject>();

    [SerializeField]
    List<GameObject> staticUI = new List<GameObject>();

    [SerializeField]
    List<TextMeshProUGUI> uiText = new List<TextMeshProUGUI>();

    [SerializeField]
    List<bool> menuChecks = new List<bool>();

    DayNightCycle dayRef;

    PlayerController player;

    FireManager fire;

    Inventory invRef;

    void Awake()
    {
        invRef = FindObjectOfType<Inventory>();
        dayRef = FindObjectOfType<DayNightCycle>();
        player = FindObjectOfType<PlayerController>();
        fire = FindObjectOfType<FireManager>();
        uiText[0].text = "DAYS: " + dayRef.GetDaysPassed().ToString();
        uiText[1].text = "0" + dayRef.GetHour() + "0" + dayRef.GetMinute().ToString();
    }

	// Use this for initialization
	void Start ()
    {
        foreach (GameObject menu in dynamicUI)
        {
            menu.SetActive(false);
        }

        dynamicUI[2].SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
    {
        PauseGame();
        OpenInventoryScreen();
        OpenCraftingScreen();
        OpenDebugMenu();
        CheckDaysPassed();
        CheckClock();
        CheckGameOver();
        CheckPartOfDay();
	}

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuChecks[3])
        {
            dynamicUI[0].SetActive(false);
            dynamicUI[1].SetActive(false);
            dynamicUI[2].SetActive(false);
            dynamicUI[3].SetActive(true);
            dynamicUI[4].SetActive(false);
            menuChecks[0] = false;
            menuChecks[1] = false;
            menuChecks[2] = false;
            menuChecks[3] = true;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuChecks[3])
        {
            dynamicUI[0].SetActive(false);
            dynamicUI[1].SetActive(false);
            dynamicUI[2].SetActive(false);
            dynamicUI[3].SetActive(false);
            dynamicUI[4].SetActive(false);
            menuChecks[0] = false;
            menuChecks[1] = false;
            menuChecks[2] = false;
            menuChecks[3] = false;
            Time.timeScale = 1f;
        }
    }

    void CheckDaysPassed()
    {
        uiText[0].text = "DAYS: " + dayRef.GetDaysPassed().ToString();
    }

    void CheckClock()
    {
        if (dayRef.GetMeridiem() == DayNightCycle.Meridiem.AM)
        {
            if (dayRef.GetHour() < 10f && dayRef.GetMinute() <= 10f)
            {
                uiText[1].text = "0" + Mathf.Abs(dayRef.GetHour()).ToString() + " : " + "0" + Mathf.Abs(dayRef.GetMinute()).ToString() + " AM";
            }

            if (dayRef.GetHour() < 10f && dayRef.GetMinute() >= 10f)
            {
                uiText[1].text = "0" + Mathf.Abs(dayRef.GetHour()).ToString() + " : " + Mathf.Abs(dayRef.GetMinute()).ToString() + " AM";
            }

            if (dayRef.GetHour() >= 10f && dayRef.GetMinute() >= 10f)
            {
                uiText[1].text = Mathf.Abs(dayRef.GetHour()) + " : " + Mathf.Abs(dayRef.GetMinute()).ToString() + " AM";
            }
        }

        if (dayRef.GetMeridiem() == DayNightCycle.Meridiem.PM)
        {
            if (dayRef.GetHour() < 10f && dayRef.GetMinute() <= 10f)
            {
                uiText[1].text = "0" + Mathf.Abs(dayRef.GetHour()).ToString() + " : " + "0" + Mathf.Abs(dayRef.GetMinute()).ToString() + " PM";
            }

            if (dayRef.GetHour() < 10f && dayRef.GetMinute() >= 10f)
            {
                uiText[1].text = "0" + Mathf.Abs(dayRef.GetHour()).ToString() + " : " + Mathf.Abs(dayRef.GetMinute()).ToString() + " PM";
            }

            if (dayRef.GetHour() >= 10f && dayRef.GetMinute() >= 10f)
            {
                uiText[1].text = Mathf.Abs(dayRef.GetHour()).ToString() + " : " + Mathf.Abs(dayRef.GetMinute()).ToString() + " PM";
            }
        }
    }

    void CheckPartOfDay()
    {
        uiText[2].text = dayRef.GetPartOfDay().ToString();
    }

    void CheckGameOver()
    {
        if (player.health.CurValue <= 0 || fire.health.CurValue <= 0)
        {
            foreach (GameObject menu in dynamicUI)
            {
                if (menu.activeInHierarchy == true)
                {
                    menu.SetActive(false);
                }
            }

            dynamicUI[5].SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    void OpenInventoryScreen()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (menuChecks[0] == false)
            {
                dynamicUI[0].SetActive(true);
                dynamicUI[1].SetActive(false);
                dynamicUI[2].SetActive(false);
                dynamicUI[4].SetActive(false);
                menuChecks[0] = true;
                menuChecks[1] = false;
            }

            else if (menuChecks[0] == true)
            {
                dynamicUI[0].SetActive(false);
                dynamicUI[1].SetActive(false);
                dynamicUI[2].SetActive(true);
                menuChecks[0] = false;
                menuChecks[1] = false;
            }
        }
    }

    void OpenCraftingScreen()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (menuChecks[1] == false)
            {
                dynamicUI[0].SetActive(false);
                dynamicUI[1].SetActive(true);
                dynamicUI[2].SetActive(false);
                dynamicUI[4].SetActive(false);
                menuChecks[0] = false;
                menuChecks[1] = true;
            }

            else if (menuChecks[1] == true)
            {
                dynamicUI[0].SetActive(false);
                dynamicUI[1].SetActive(false);
                dynamicUI[2].SetActive(true);
                menuChecks[0] = false;
                menuChecks[1] = false;
            }
        }
    }

    void OpenDebugMenu()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (menuChecks[2] == false)
            {
                dynamicUI[0].SetActive(false);
                dynamicUI[1].SetActive(false);
                dynamicUI[2].SetActive(false);
                dynamicUI[4].SetActive(true);
                menuChecks[0] = false;
                menuChecks[1] = false;
                menuChecks[2] = true;
            }

            else if (menuChecks[2] == true)
            {
                dynamicUI[0].SetActive(false);
                dynamicUI[1].SetActive(false);
                dynamicUI[2].SetActive(true);
                dynamicUI[4].SetActive(false);
                menuChecks[0] = false;
                menuChecks[1] = false;
                menuChecks[2] = false;
            }
        }
    }

    public void OnClickRetry()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
