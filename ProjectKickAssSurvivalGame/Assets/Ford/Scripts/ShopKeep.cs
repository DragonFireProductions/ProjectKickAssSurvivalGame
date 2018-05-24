using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeep : MonoBehaviour
{
    [SerializeField]
    GameObject ShopKeepMenu;

    GameObject player;

    Inventory inv;

    PlayerController playerC;

    public bool dronePurchased;

    void Start()
    {
        ShopKeepMenu.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerC = FindObjectOfType<PlayerController>();
        inv = FindObjectOfType<Inventory>();
        dronePurchased = false;
    }


    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenShop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseShop();
        }
    }

    void OpenShop()
    {
        if (Input.GetKeyDown(KeyCode.O) && ShopKeepMenu.activeInHierarchy == false)
        {
            ShopKeepMenu.SetActive(true);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.O) && ShopKeepMenu.activeInHierarchy == true)
            {
                CloseShop();
            }
        }
    }

    void CloseShop()
    {
        ShopKeepMenu.SetActive(false);
    }

    public void OnClickBuyBWall()
    {
        if (inv.coin_resource >= 10)
        {
            inv.craftedBurlapWall++;
            inv.coin_resource -= 10;
        }
        else
        {
            Debug.Log("no coinas");
        }
        
    }

    public void OnClickBuyWWall()
    {
        if (inv.coin_resource >= 25)
        {
            inv.craftedWoodFence++;
            inv.coin_resource -= 25;
        }
    }

    public void OnClickBuyWTurret()
    {
        if (inv.coin_resource >= 50)
        {
            inv.craftedWoodTurret++;
            inv.coin_resource -= 50;
        }
    }

    public void OnClickBuyBArmor()
    {
        if (inv.coin_resource >= 25 && playerC.damageReduction < 1)
        {
            playerC.damageReduction = 1;
            inv.coin_resource -= 25;
        } 
    }

    public void OnClickBuyWArmor()
    {
        if (inv.coin_resource >= 50 && playerC.damageReduction < 2)
        {
            playerC.damageReduction = 2;
            inv.coin_resource -= 50;
        }
    }

    public void OnClickBuyDrone()
    {
        if (inv.coin_resource >= 200 && dronePurchased == false)
        {
            dronePurchased = true;
            inv.coin_resource -= 200;
        }
    }
}
