using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    #region//Crafting completion criteria bools

    [SerializeField] private bool CanCraft_BurlapWall, CanCraft_WoodFence, CanCraft_StoneFence, CanCraft_MetalFence, CanCraft_WoodTurret,
    CanCraft_StoneTurret, CanCraft_MetalTurret, CanCraft_BurlapArmor, CanCraft_WoodArmor, CanCraft_StoneArmor, CanCraft_MetalArmor, CanCraft_SpikeTrap, CanCraft_BearTrap;

    #endregion

    #region//Crafting Game Objects

    [SerializeField] private GameObject G_BurlapWall, G_WoodFence, G_StoneFence, G_MetalFence, G_WoodTurret, G_StoneTurret, G_MetalTurret,
    G_BurlapArmor, G_WoodArmor, G_StoneArmor, G_MetalArmor, G_SpikeTrap, G_BearTrap;

    #endregion

    //Access to inventory script
    private Inventory Inv;

    private void Start()
    {
        Inv = GetComponent<Inventory>();

        //Crafting completion criteria bools set to false on start
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
    }

    void Update ()
    {
        WoodFence();
        StoneFence();
	}

    #region//Craftable Item Functions

    private void BurlapWall()
    {
        if (Inv.sand_resource >= 1 && Inv.rope_resource >= 1)
        {
            CanCraft_BurlapWall = true;
        }

        if (CanCraft_BurlapWall == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(G_BurlapWall, transform.position + (transform.forward * 5), transform.rotation);
                Inv.sand_resource--;
                Inv.rope_resource--;
            }
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

    #endregion
}
