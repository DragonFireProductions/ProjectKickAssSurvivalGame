using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    void Awake()
    {
        dayRef = FindObjectOfType<DayNightCycle>();
        player = FindObjectOfType<PlayerController>();
        uiText[4].text = "DAYS: " + dayRef.GetDaysPassed().ToString();
        uiText[5].text = "0" + dayRef.GetHour() + "0" + dayRef.GetMinute().ToString();
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
        OpenInventoryScreen();
        OpenCraftingScreen();
        OpenDebugMenu();
        CheckDaysPassed();
        CheckClock();
        CheckGameOver();
	}

    void CheckDaysPassed()
    {
        uiText[4].text = "DAYS: " + dayRef.GetDaysPassed().ToString();
    }

    void CheckClock()
    {
        if (dayRef.GetHour() < 10f && dayRef.GetMinute() <= 10f)
        {
            uiText[5].text = "0" + Mathf.Abs(dayRef.GetHour()) + " : " + "0" + Mathf.Abs(dayRef.GetMinute()).ToString();
        }

        if (dayRef.GetHour() < 10f && dayRef.GetMinute() >= 10f)
        {
            uiText[5].text = "0" + Mathf.Abs(dayRef.GetHour()) + " : " + Mathf.Abs(dayRef.GetMinute()).ToString();
        }

        if (dayRef.GetHour() >= 10f && dayRef.GetMinute() >= 10f)
        {
            uiText[5].text = Mathf.Abs(dayRef.GetHour()) + " : " + Mathf.Abs(dayRef.GetMinute()).ToString();
        }
    }

    void CheckGameOver()
    {
        if (player.health.CurValue <= 0)
        {
            foreach (GameObject menu in dynamicUI)
            {
                if (menu.activeInHierarchy == true)
                {
                    menu.SetActive(false);
                }
            }

            dynamicUI[3].SetActive(true);
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
}
