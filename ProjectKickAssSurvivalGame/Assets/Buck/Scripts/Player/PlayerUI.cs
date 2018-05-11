﻿using System.Collections.Generic;
using UnityEngine;
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

    [Header("UIElements")]
    [SerializeField]
    GameObject playerInventoryScreen;

    [SerializeField]
    GameObject playerCraftingScreen;

    [SerializeField]
    GameObject playerToolBelt;

    Inventory inventoryRef;

    WaveSpawner dayRef;

    bool inventoryOpened;
    bool craftingOpened;

    void Awake()
    {
<<<<<<< HEAD
        inventoryRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        dayRef = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<WaveSpawner>();
        coinsText.text = "COINS: " + Mathf.Round(inventoryRef.coin).ToString();
        woodText.text = "WOOD: " + Mathf.Round(inventoryRef.wood).ToString();
        stoneText.text = "STONE: " + Mathf.Round(inventoryRef.stone).ToString();
        ironText.text = "IRON: " + Mathf.Round(inventoryRef.iron).ToString();
        dayCounter.text = "DAY: " + Mathf.Round(dayRef.daysPassed).ToString();
=======
        inventoryRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        coinsText.text = "COINS: " + Mathf.Round(inventoryRef.coin_resource).ToString();
        woodText.text = "WOOD: " + Mathf.Round(inventoryRef.wood_resource).ToString();
        stoneText.text = "STONE: " + Mathf.Round(inventoryRef.stone_resource).ToString();
        ironText.text = "IRON: " + Mathf.Round(inventoryRef.metal_resource).ToString();
>>>>>>> 16195f09f8ff4a2cdfb9888d5270e1f9620f96cc
    }

    // Update is called once per frame
    void Update()
    {
        OpenInventoryScreen();
        OpenCraftingScreen();
        CheckResourceAmounts();
        CheckDaysSurvived();
    }

    void CheckResourceAmounts()
    {
        coinsText.text = "COINS: " + Mathf.Round(inventoryRef.coin_resource).ToString();
        woodText.text = "WOOD: " + Mathf.Round(inventoryRef.wood_resource).ToString();
        stoneText.text = "STONE: " + Mathf.Round(inventoryRef.stone_resource).ToString();
        ironText.text = "IRON: " + Mathf.Round(inventoryRef.metal_resource).ToString();
    }

    void CheckDaysSurvived()
    {
        dayCounter.text = "DAY: " + Mathf.Round(dayRef.daysPassed).ToString();
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

            else if (craftingOpened == true)
            {
                craftingOpened = false;
            }

            else if (inventoryOpened == false && craftingOpened == true)
            {
                playerToolBelt.SetActive(false);
            }

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

            else if (inventoryOpened == true)
            {
                inventoryOpened = false;
            }

            else if (craftingOpened == false && inventoryOpened == true)
            {
                playerToolBelt.SetActive(false);
            }

            else if (craftingOpened == true)
            {
                playerCraftingScreen.SetActive(false);
                playerToolBelt.SetActive(true);
                craftingOpened = false;
            }
        }
    }
}
