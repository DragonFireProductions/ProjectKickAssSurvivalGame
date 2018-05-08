using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public Text coinText;

    [HideInInspector]
    public int coin;

    [HideInInspector]
    public int wood;

    [HideInInspector]
    public int stone;

    public GameObject playerInventory;

    bool inventoryActive;

    void Awake()
    {
        coinText.text = "Coins: ";
        inventoryActive = false;
        playerInventory.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        OpenInventory();
        SetResourceCount();
	}

    void OnTriggetEnter(Collider resource)
    {
        if (resource.tag == "Coin")
        {
            coin++;
        }
    }

    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I) && inventoryActive == false)
        {
            playerInventory.SetActive(true);
            inventoryActive = true;
        }

        else if(Input.GetKeyDown(KeyCode.I) && inventoryActive == true)
        {
            playerInventory.SetActive(false);
            inventoryActive = false;
        }
    }

    void SetResourceCount()
    {
        coinText.text = "Coins: " + coin.ToString();
    }
}
