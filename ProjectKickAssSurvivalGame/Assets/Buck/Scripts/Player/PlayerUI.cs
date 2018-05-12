using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    [Header("TextFields")]
    [SerializeField]
    TextMeshProUGUI coinsText;

    [SerializeField]
    TextMeshProUGUI woodText;

    [SerializeField]
    TextMeshProUGUI stoneText;

    [SerializeField]
    TextMeshProUGUI ironText;

    [SerializeField]
    TextMeshProUGUI dayCounter;

    [SerializeField]
    TextMeshProUGUI clockCounter;

    [Header("UIElements")]
    [SerializeField]
    GameObject playerInventoryScreen;

    [SerializeField]
    GameObject playerCraftingScreen;

    [SerializeField]
    GameObject playerToolBelt;

    [SerializeField]
    Image playerHealthBar;

    [SerializeField]
    GameObject clock;

    [Header("PlayerHealthBarSettings")]

    [SerializeField]
    float fillAmount;

    [SerializeField]
    float lerpSpeed;

    [SerializeField]
    Color fullColor, emptyColor;

    PlayerHealth healthRef;

    Inventory inventoryRef;

    WaveSpawner dayRef;

    DayNightCycle timeRef;

    bool inventoryOpened;
    bool craftingOpened;

    void Awake()
    {
        inventoryRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        healthRef = GameObject.Find("Player").GetComponent<PlayerHealth>();
        dayRef = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<WaveSpawner>();
        timeRef = GameObject.FindGameObjectWithTag("Sun").GetComponent<DayNightCycle>();
        coinsText.text = "COINS: " + Mathf.Round(inventoryRef.coin_resource).ToString();
        woodText.text = "WOOD: " + Mathf.Round(inventoryRef.wood_resource).ToString();
        stoneText.text = "STONE: " + Mathf.Round(inventoryRef.stone_resource).ToString();
        ironText.text = "IRON: " + Mathf.Round(inventoryRef.iron_resource).ToString();
        dayCounter.text = "DAY: " + Mathf.Round(dayRef.daysPassed).ToString();
        clockCounter.text = "0" + Mathf.Abs(timeRef.GetHour()) + " : " + "0" + Mathf.Abs(timeRef.GetMinute()).ToString();

        playerHealthBar.color = fullColor;
    }

    // Update is called once per frame
    void Update()
    {
        OpenInventoryScreen();
        OpenCraftingScreen();
        CheckResourceAmounts();
        CheckDaysSurvived();
        CheckClock();
        //HandlePlayerHealthBar();
    }

    //NEEDS MORE COWBELL BEFORE COMPLETE FUK ALL DIS SHIT, I'M GOING TO BED
    //void HandlePlayerHealthBar()
    //{
    //    playerHealthBar.fillAmount = healthRef.healthBar.fillAmount;

    //    if (fillAmount != playerHealthBar.fillAmount)
    //    {
    //        playerHealthBar.fillAmount = Mathf.Lerp(playerHealthBar.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
    //    }

    //}

    void CheckResourceAmounts()
    {
        coinsText.text = "COINS: " + Mathf.Round(inventoryRef.coin_resource).ToString();
        woodText.text = "WOOD: " + Mathf.Round(inventoryRef.wood_resource).ToString();
        stoneText.text = "STONE: " + Mathf.Round(inventoryRef.stone_resource).ToString();
        ironText.text = "IRON: " + Mathf.Round(inventoryRef.iron_resource).ToString();
    }

    void CheckDaysSurvived()
    {
        dayCounter.text = "DAY: " + Mathf.Round(dayRef.daysPassed).ToString();
    }

    void CheckClock()
    {
        if (timeRef.GetHour() < 10f && timeRef.GetMinute() <= 10f)
        {
            clockCounter.text = "0" + Mathf.Abs(timeRef.GetHour()) + " : " + "0" + Mathf.Abs(timeRef.GetMinute()).ToString();
        }

        if (timeRef.GetHour() < 10f && timeRef.GetMinute() >= 10f)
        {
            clockCounter.text = "0" + Mathf.Abs(timeRef.GetHour()) + " : " + Mathf.Abs(timeRef.GetMinute()).ToString();
        }

        if(timeRef.GetHour() >= 10f && timeRef.GetMinute() >= 10f)
        {
            clockCounter.text = Mathf.Abs(timeRef.GetHour()) + " : " + Mathf.Abs(timeRef.GetMinute()).ToString();
        }
    }

    void OpenInventoryScreen()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryOpened == false)
            {
                playerInventoryScreen.SetActive(true);
                playerCraftingScreen.SetActive(false);
                playerToolBelt.SetActive(false);
                inventoryOpened = true;
            }

            //else if (inventoryOpened == false && craftingOpened == true)
            //{
            //    playerToolBelt.SetActive(false);
            //}

            else if (inventoryOpened == true)
            {
                playerInventoryScreen.SetActive(false);
                playerToolBelt.SetActive(true);
                inventoryOpened = false;
            }
        }

    }

    void OpenCraftingScreen()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (craftingOpened == false)
            {
                playerInventoryScreen.SetActive(false);
                playerCraftingScreen.SetActive(true);
                playerToolBelt.SetActive(false);
                craftingOpened = true;
            }

            //else if (craftingOpened == false && inventoryOpened == true)
            //{
            //    playerToolBelt.SetActive(false);
            //}

            else if (craftingOpened == true)
            {
                playerCraftingScreen.SetActive(false);
                playerToolBelt.SetActive(true);
                craftingOpened = false;
            }
        }
    }
}
