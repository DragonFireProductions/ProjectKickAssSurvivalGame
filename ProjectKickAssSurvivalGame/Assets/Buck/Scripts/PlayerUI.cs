using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    [Header("TextFields")]
    [SerializeField]
    TextMeshProUGUI coinsText;

    [SerializeField]
    TextMeshProUGUI woodText;

    PlayeInventory inventoryRef;

    [Header("UIElements")]
    [SerializeField]
    GameObject playerInventoryScreen;

    [SerializeField]
    GameObject playerToolBelt;

    bool inventoryOpened;

    void Awake()
    {
        coinsText.text = "COINS: " + Mathf.Round(inventoryRef.coin).ToString();
        woodText.text = "WOOD: " + Mathf.Round(inventoryRef.wood).ToString();
        playerInventoryScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpenInventoryScreen();
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
