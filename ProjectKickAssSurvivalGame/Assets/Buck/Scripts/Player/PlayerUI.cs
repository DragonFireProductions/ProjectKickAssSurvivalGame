using System.Collections.Generic;
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
    GameObject playerToolBelt;

    PlayerInventory inventoryRef;

    WaveSpawner dayRef;

    bool inventoryOpened;

    void Awake()
    {
        inventoryRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        dayRef = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<WaveSpawner>();
        coinsText.text = "COINS: " + Mathf.Round(inventoryRef.coin).ToString();
        woodText.text = "WOOD: " + Mathf.Round(inventoryRef.wood).ToString();
        stoneText.text = "STONE: " + Mathf.Round(inventoryRef.stone).ToString();
        ironText.text = "IRON: " + Mathf.Round(inventoryRef.iron).ToString();
        dayCounter.text = "DAY: " + Mathf.Round(dayRef.daysPassed).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        OpenInventoryScreen();
        CheckResourceAmounts();
        CheckDaysSurvived();
    }

    void CheckResourceAmounts()
    {
        coinsText.text = "COINS: " + Mathf.Round(inventoryRef.coin).ToString();
        woodText.text = "WOOD: " + Mathf.Round(inventoryRef.wood).ToString();
        stoneText.text = "STONE: " + Mathf.Round(inventoryRef.stone).ToString();
        ironText.text = "IRON: " + Mathf.Round(inventoryRef.iron).ToString();
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
                playerToolBelt.SetActive(false);
                inventoryOpened = true;
            }

            else if (inventoryOpened == true)
            {
                playerInventoryScreen.SetActive(false);
                playerToolBelt.SetActive(true);
                inventoryOpened = false;
            }
        }

    }
}
