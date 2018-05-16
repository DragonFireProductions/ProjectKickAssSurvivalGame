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
    }

    #region//Craftable Item Functions

    public void BurlapWall()
    {
        if (Inv.sand_resource >= 1 && Inv.rope_resource >= 1)
        {
            CanCraft_BurlapWall = true;
        }

        if (CanCraft_BurlapWall == true)
        {
            Inv.sand_resource--;
            Inv.rope_resource--;
            Inv.craftedBurlapWall++;
        }

        if (Inv.sand_resource <= 0 && Inv.rope_resource <= 0)
        {
            CanCraft_BurlapWall = false;
        }
    }

    public void WoodFence()
    {
        if (Inv.wood_resource >= 3)
        {
            CanCraft_WoodFence = true;
        }

        if (CanCraft_WoodFence == true)
        {
            Inv.wood_resource = Inv.wood_resource - 3;
            Inv.craftedWoodFence++;
        }

        if (Inv.wood_resource < 3)
        {
            CanCraft_WoodFence = false;
        }
    }

    public void StoneFence()
    {
        if (Inv.stone_resource >= 5)
        {
            CanCraft_StoneFence = true;
        }

        if (CanCraft_StoneFence == true)
        {
            Inv.stone_resource = Inv.stone_resource - 5;
            Inv.craftedStoneFence++;
        }

        if (Inv.stone_resource < 5)
        {
            CanCraft_StoneFence = false;
        }
    }

    public void MetalFence()
    {
        if (Inv.iron_resource >= 10)
        {
            CanCraft_MetalFence = true;
        }

        if (CanCraft_MetalFence == true)
        {
            Inv.iron_resource = Inv.iron_resource - 10;
            Inv.craftedMetalFence++;
        }

        if (Inv.iron_resource < 10)
        {
            CanCraft_MetalFence = false;
        }
    }

    public void WoodTurret()
    {
        if (Inv.wood_resource >= 21)
        {
            CanCraft_WoodTurret = true;
        }

        if (CanCraft_WoodTurret == true)
        {
            Inv.wood_resource = Inv.wood_resource - 21;
            Inv.craftedWoodTurret++;
        }

        if (Inv.wood_resource < 21)
        {
            CanCraft_WoodTurret = false;
        }
    }

    public void StoneTurret()
    {
        if (Inv.stone_resource >= 35)
        {
            CanCraft_StoneTurret = true;
        }

        if (CanCraft_StoneTurret == true)
        {
            Inv.stone_resource = Inv.stone_resource - 35;
            Inv.craftedStoneTurret++;
        }

        if (Inv.stone_resource < 35)
        {
            CanCraft_StoneTurret = false;
        }
    }

    public void MetalTurret()
    {
        if (Inv.iron_resource >= 70)
        {
            CanCraft_MetalTurret = true;
        }

        if (CanCraft_MetalTurret == true)
        {
            Inv.iron_resource = Inv.iron_resource - 70;
            Inv.craftedMetalTurret++;
        }

        if (Inv.iron_resource < 70)
        {
            CanCraft_MetalTurret = false;
        }
    }

    public void BurlapArmor()
    {
        if (Inv.sand_resource >= 7 && Inv.rope_resource >= 7)
        {
            CanCraft_BurlapArmor = true;
        }

        if (CanCraft_BurlapArmor == true)
        {
            Inv.sand_resource = Inv.sand_resource - 7;
            Inv.rope_resource = Inv.rope_resource - 7;
            Inv.craftedBurlapArmor++;
        }

        if (Inv.sand_resource < 7 && Inv.rope_resource < 7)
        {
            CanCraft_BurlapArmor = false;
        }
    }

    public void WoodArmor()
    {
        if (Inv.wood_resource >= 10)
        {
            CanCraft_WoodArmor = true;
        }

        if (CanCraft_WoodArmor == true)
        {
            Inv.wood_resource = Inv.wood_resource - 10;
            Inv.craftedWoodArmor++;
        }

        if (Inv.wood_resource < 10)
        {
            CanCraft_WoodArmor = false;
        }
    }

    public void StoneArmor()
    {
        if (Inv.stone_resource >= 20)
        {
            CanCraft_StoneArmor = true;
        }

        if (CanCraft_StoneArmor == true)
        {
            Inv.stone_resource = Inv.stone_resource - 20;
            Inv.craftedStoneArmor++;
        }

        if (Inv.stone_resource < 20)
        {
            CanCraft_StoneArmor = false;
        }
    }

    public void MetalArmor()
    {
        if (Inv.iron_resource >= 50)
        {
            CanCraft_MetalArmor = true;
        }

        if (CanCraft_MetalArmor == true)
        {
            Inv.iron_resource = Inv.iron_resource - 50;
            Inv.craftedMetalArmor++;
        }

        if (Inv.iron_resource < 50)
        {
            CanCraft_MetalArmor = false;
        }
    }

    public void SpikeTrap()
    {
        if (Inv.iron_resource >= 15)
        {
            CanCraft_SpikeTrap = true;
        }

        if (CanCraft_SpikeTrap == true)
        {
            Inv.iron_resource = Inv.iron_resource - 15;
            Inv.craftedSpikeTrap++;
        }

        if (Inv.iron_resource < 15)
        {
            CanCraft_SpikeTrap = false;
        }
    }

    public void BearTrap()
    {
        if (Inv.iron_resource >= 25)
        {
            CanCraft_BearTrap = true;
        }

        if (CanCraft_BearTrap == true)
        {
            Inv.iron_resource = Inv.iron_resource - 25;
            Inv.craftedBearTrap++;
        }

        if (Inv.iron_resource < 25)
        {
            CanCraft_BearTrap = false;
        }
    }

    #endregion

}
