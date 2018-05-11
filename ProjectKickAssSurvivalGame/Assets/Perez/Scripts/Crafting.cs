using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    #region//Crafting completion criteria bools

    bool CanCraft_BurlapWall, CanCraft_WoodFence, CanCraft_StoneFence, CanCraft_MetalFence, CanCraft_WoodTurret,
    CanCraft_StoneTurret, CanCraft_MetalTurret, CanCraft_BurlapArmor, CanCraft_WoodArmor, CanCraft_StoneArmor, CanCraft_MetalArmor, CanCraft_SpikeTrap, CanCraft_BearTrap;

    #endregion

    #region//Crafting Game Objects

    [SerializeField] private GameObject G_BurlapWall, G_WoodFence, G_StoneFence, G_MetalFence, G_WoodTurret, G_StoneTurret, G_MetalTurret,
    G_BurlapArmor, G_WoodArmor, G_StoneArmor, G_MetalArmor, G_SpikeTrap, G_BearTrap;

    #endregion

    #region//Serialized Buttons

    //[SerializeField] Button B_BurlapWall, B_WoodFence, B_StoneFence, B_MetalFence, B_WoodTurret,
    //B_StoneTurret, B_MetalTurret, B_BurlapArmor, B_WoodArmor, B_StoneArmor, B_MetalArmor, B_SpikeTrap, B_BearTrap;

    #endregion

    #region//Button Colorblocks

    //ColorBlock colors1 = B_BurlapWall.colors;
    //ColorBlock colors2 = B_WoodFence.colors;
    //ColorBlock colors3 = B_StoneFence.colors;
    //ColorBlock colors4 = B_MetalFence.colors;
    //ColorBlock colors5 = B_WoodTurret.colors;
    //ColorBlock colors6 = B_StoneTurret.colors;
    //ColorBlock colors7 = B_MetalTurret.colors;
    //ColorBlock colors8 = B_BurlapArmor.colors;
    //ColorBlock colors9 = B_WoodArmor.colors;
    //ColorBlock colors10 = B_StoneArmor.colors;
    //ColorBlock colors11 = B_MetalArmor.colors;
    //ColorBlock colors12 = B_SpikeTrap.colors;
    //ColorBlock colors13 = B_BearTrap.colors;

    #endregion

    //Access to inventory script

    private Inventory Inv;

    

    private void Start()
    {
        Inv = GetComponent<Inventory>();

        #region//Crafting Completion Bools Set To False At Start

        CanCraft_BurlapWall = false;
        CanCraft_WoodFence = false;
        CanCraft_StoneFence = false;
        CanCraft_MetalFence = false;
        CanCraft_WoodTurret = false;
        CanCraft_StoneTurret = false;
        CanCraft_MetalTurret = false;
        CanCraft_BurlapArmor = false;
        CanCraft_WoodArmor = false;
        CanCraft_StoneArmor = false;
        CanCraft_MetalArmor = false;
        CanCraft_SpikeTrap = false;
        CanCraft_BearTrap = false;

        #endregion

        #region//Set Button Colors To Red At Start

        //colors1.normalColor = Color.red;
        //colors1.highlightedColor = Color.red;
        //B_BurlapWall.colors = colors1;

        //colors2.normalColor = Color.red;
        //colors2.highlightedColor = Color.red;
        //B_WoodFence.colors = colors2;

        //colors3.normalColor = Color.red;
        //colors3.highlightedColor = Color.red;
        //B_StoneFence.colors = colors3;

        //colors4.normalColor = Color.red;
        //colors4.highlightedColor = Color.red;
        //B_MetalFence.colors = colors4;

        //colors5.normalColor = Color.red;
        //colors5.highlightedColor = Color.red;
        //B_WoodTurret.colors = colors5;

        //colors6.normalColor = Color.red;
        //colors6.highlightedColor = Color.red;
        //B_StoneTurret.colors = colors6;

        //colors7.normalColor = Color.red;
        //colors7.highlightedColor = Color.red;
        //B_MetalTurret.colors = colors7;

        //colors8.normalColor = Color.red;
        //colors8.highlightedColor = Color.red;
        //B_BurlapArmor.colors = colors8;

        //colors9.normalColor = Color.red;
        //colors9.highlightedColor = Color.red;
        //B_WoodArmor.colors = colors9;

        //colors10.normalColor = Color.red;
        //colors10.highlightedColor = Color.red;
        //B_StoneArmor.colors = colors10;

        //colors11.normalColor = Color.red;
        //colors11.highlightedColor = Color.red;
        //B_MetalArmor.colors = colors11;

        //colors12.normalColor = Color.red;
        //colors12.highlightedColor = Color.red;
        //B_SpikeTrap.colors = colors12;

        //colors13.normalColor = Color.red;
        //colors13.highlightedColor = Color.red;
        //B_BearTrap.colors = colors13;

        #endregion
    }

    void Update ()
    {
        //SetButtonsToGreen();
	}

    //void SetButtonsToGreen()
    //{
    //    if (CanCraft_BurlapWall == true)
    //    {
    //        colors1.normalColor = Color.green;
    //        colors1.highlightedColor = Color.green;
    //        B_BurlapWall.colors = colors1;
    //    }
    //}

    public void BurlapWall()
    {
        if (Inv.sand_resource >= 1 && Inv.rope_resource >= 1)
        {
            CanCraft_BurlapWall = true;
        }

        if (CanCraft_BurlapWall == true)
        {
            Instantiate(G_BurlapWall, transform.position + (transform.forward * 5), transform.rotation);
            Inv.sand_resource--;
            Inv.rope_resource--;
        }

        if (Inv.sand_resource <= 0 && Inv.rope_resource <= 0)
        {
            CanCraft_BurlapWall = false;
        }
    }

    private void WoodFence()
    {
        if (Inv.wood_resource >= 1)
        {
            CanCraft_WoodFence = true;
        }

        if (CanCraft_WoodFence == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(G_WoodFence, transform.position + (transform.forward * 5), transform.rotation);
                Inv.wood_resource--;
            }
        }

        if (Inv.wood_resource <= 0)
        {
            CanCraft_WoodFence = false;
        }
    }

    private void StoneFence()
    {
        if (Inv.stone_resource >= 1)
        {
            CanCraft_StoneFence = true;
        }

        if (CanCraft_StoneFence == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(G_StoneFence, transform.position + (transform.forward * 5), transform.rotation);
                Inv.stone_resource--;
            }
        }

        if (Inv.stone_resource <= 0)
        {
            CanCraft_StoneFence = false;
        }
    }

    private void MetalFence()
    {
        if (Inv.metal_resource >= 1)
        {
            CanCraft_MetalFence = true;
        }

        if (CanCraft_MetalFence == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(G_MetalFence, transform.position + (transform.forward * 5), transform.rotation);
                Inv.metal_resource--;
            }
        }

        if (Inv.metal_resource <= 0)
        {
            CanCraft_MetalFence = false;
        }
    }

    private void WoodTurret()
    {
        if (Inv.wood_resource >= 1)
        {
            CanCraft_WoodTurret = true;
        }

        if (CanCraft_WoodTurret == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(G_WoodTurret, transform.position + (transform.forward * 5), transform.rotation);
                Inv.wood_resource--;
            }
        }

        if (Inv.wood_resource <= 0)
        {
            CanCraft_WoodTurret = false;
        }
    }

    private void StoneTurret()
    {
        if (Inv.stone_resource >= 1)
        {
            CanCraft_StoneTurret = true;
        }

        if (CanCraft_StoneTurret == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(G_StoneTurret, transform.position + (transform.forward * 5), transform.rotation);
                Inv.stone_resource--;
            }
        }

        if (Inv.stone_resource <= 0)
        {
            CanCraft_StoneTurret = false;
        }
    }

    private void MetalTurret()
    {
        if (Inv.metal_resource >= 1)
        {
            CanCraft_MetalTurret = true;
        }

        if (CanCraft_MetalTurret == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(G_MetalTurret, transform.position + (transform.forward * 5), transform.rotation);
                Inv.metal_resource--;
            }
        }

        if (Inv.metal_resource <= 0)
        {
            CanCraft_MetalTurret = false;
        }
    }

    private void BurlapArmor()
    {
        if (Inv.sand_resource >= 1 && Inv.rope_resource >= 1)
        {
            CanCraft_BurlapArmor = true;
        }

        if (CanCraft_BurlapArmor == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(G_BurlapArmor, transform.position + (transform.forward * 5), transform.rotation);
                Inv.wood_resource--;
            }
        }

        if (Inv.wood_resource <= 0)
        {
            CanCraft_WoodTurret = false;
        }
    }
}
