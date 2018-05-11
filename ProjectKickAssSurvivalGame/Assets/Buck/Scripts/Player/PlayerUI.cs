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

    [Header("UIElements")]
    [SerializeField]
    GameObject playerInventoryScreen;

    [SerializeField]
    GameObject playerCraftingScreen;

    [SerializeField]
    GameObject playerToolBelt;

    Inventory inventoryRef;

    bool inventoryOpened;
    bool craftingOpened;

    void Awake()
    {
        inventoryRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        coinsText.text = "COINS: " + Mathf.Round(inventoryRef.coin_resource).ToString();
        woodText.text = "WOOD: " + Mathf.Round(inventoryRef.wood_resource).ToString();
        stoneText.text = "STONE: " + Mathf.Round(inventoryRef.stone_resource).ToString();
        ironText.text = "IRON: " + Mathf.Round(inventoryRef.metal_resource).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        OpenInventoryScreen();
        OpenCraftingScreen();
        CheckResourceAmounts();
    }

    void CheckResourceAmounts()
    {
        coinsText.text = "COINS: " + Mathf.Round(inventoryRef.coin_resource).ToString();
        woodText.text = "WOOD: " + Mathf.Round(inventoryRef.wood_resource).ToString();
        stoneText.text = "STONE: " + Mathf.Round(inventoryRef.stone_resource).ToString();
        ironText.text = "IRON: " + Mathf.Round(inventoryRef.metal_resource).ToString();
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
