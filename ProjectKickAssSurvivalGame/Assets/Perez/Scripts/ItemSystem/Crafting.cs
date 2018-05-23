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

    #region//Public Craftable Game Objects

    [SerializeField] private GameObject G_BurlapWall, G_WoodFence, G_StoneFence, G_MetalFence, G_WoodTurret, G_StoneTurret, G_MetalTurret,
    G_BurlapArmor, G_WoodArmor, G_StoneArmor, G_MetalArmor, G_SpikeTrap, G_BearTrap;

    #endregion

    #region//Armor Buttons Being Turned Off and Reference to Player Crafting Menu

    //The crafting menu is on at awake so it's components can be found by GameObject.Find

    [SerializeField] GameObject playerCraftingMenu;
    
    //After an armor piece is made, the damage reduction is increased and the 
    //corresponding button is removed from the crafting menu

    GameObject B_BurlapArmor;
    GameObject B_WoodArmor;
    GameObject B_StoneArmor;
    GameObject B_MetalArmor;

    #endregion

    #region//Pubic Item Assets

    public Item item_BurlapWall;
    public Item item_WoodFence;
    public Item item_StoneFence;
    public Item item_MetalFence;
    public Item item_WoodTurret;
    public Item item_StoneTurret;
    public Item item_MetalTurret;
    public Item item_BurlapArmor;
    public Item item_WoodArmor;
    public Item item_StoneArmor;
    public Item item_MetalArmor;
    public Item item_SpikeTrap;
    public Item item_BearTrap;

    #endregion

    #region//Script Accessors

    //Access to inventory script
    private Inventory Inv;
    //Access to toolbelt script
    private ToolBelt belt;
    //Access to the playercontroller script
    private PlayerController player;

    #endregion

    private void Awake()
    {
        playerCraftingMenu.SetActive(true);
    }

    private void Start()
    {
        Inv = GetComponent<Inventory>();
        belt = GetComponent<ToolBelt>();
        player = GetComponent<PlayerController>();

        B_BurlapArmor = GameObject.Find("Burlap Armor");
        B_WoodArmor = GameObject.Find("Wood Armor");
        B_StoneArmor = GameObject.Find("Stone Armor");
        B_MetalArmor = GameObject.Find("Metal Armor");
        playerCraftingMenu.SetActive(false);

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

        else if (Inv.sand_resource <= 0 && Inv.rope_resource <= 0)
        {
            CanCraft_BurlapWall = false;
        }

        if (CanCraft_BurlapWall == true)
        {
            Inv.sand_resource--;
            Inv.rope_resource--;
            Inv.craftedBurlapWall++;
            belt.AddItem(item_BurlapWall);
        }
    }

    public void WoodFence()
    {
        if (Inv.wood_resource >= 3)
        {
            CanCraft_WoodFence = true;
        }

        else if (Inv.wood_resource < 3)
        {
            CanCraft_WoodFence = false;
        }

        if (CanCraft_WoodFence == true)
        {
            Inv.wood_resource = Inv.wood_resource - 3;
            Inv.craftedWoodFence++;
            belt.AddItem(item_WoodFence);
        }
    }

    public void StoneFence()
    {
        if (Inv.stone_resource >= 5)
        {
            CanCraft_StoneFence = true;
        }

        else if (Inv.stone_resource < 5)
        {
            CanCraft_StoneFence = false;
        }

        if (CanCraft_StoneFence == true)
        {
            Inv.stone_resource = Inv.stone_resource - 5;
            Inv.craftedStoneFence++;
            belt.AddItem(item_StoneFence);
        }
    }

    public void MetalFence()
    {
        if (Inv.iron_resource >= 10)
        {
            CanCraft_MetalFence = true;
        }

        else if (Inv.iron_resource < 10)
        {
            CanCraft_MetalFence = false;
        }

        if (CanCraft_MetalFence == true)
        {
            Inv.iron_resource = Inv.iron_resource - 10;
            Inv.craftedMetalFence++;
            belt.AddItem(item_MetalFence);
        }
    }

    public void WoodTurret()
    {
        if (Inv.wood_resource >= 21)
        {
            CanCraft_WoodTurret = true;
        }

        else if (Inv.wood_resource < 21)
        {
            CanCraft_WoodTurret = false;
        }

        if (CanCraft_WoodTurret == true)
        {
            Inv.wood_resource = Inv.wood_resource - 21;
            Inv.craftedWoodTurret++;
            belt.AddItem(item_WoodTurret);
        }
    }

    public void StoneTurret()
    {
        if (Inv.stone_resource >= 35)
        {
            CanCraft_StoneTurret = true;
        }

        else if (Inv.stone_resource < 35)
        {
            CanCraft_StoneTurret = false;
        }

        if (CanCraft_StoneTurret == true)
        {
            Inv.stone_resource = Inv.stone_resource - 35;
            Inv.craftedStoneTurret++;
            belt.AddItem(item_StoneTurret);
        }
    }

    public void MetalTurret()
    {
        if (Inv.iron_resource >= 70)
        {
            CanCraft_MetalTurret = true;
        }

        else if (Inv.iron_resource < 70)
        {
            CanCraft_MetalTurret = false;
        }

        if (CanCraft_MetalTurret == true)
        {
            Inv.iron_resource = Inv.iron_resource - 70;
            Inv.craftedMetalTurret++;
            belt.AddItem(item_MetalTurret);
        }
    }

    public void BurlapArmor()
    {
        if (Inv.sand_resource >= 7 && Inv.rope_resource >= 7)
        {
            CanCraft_BurlapArmor = true;
        }

        else if (Inv.sand_resource < 7 && Inv.rope_resource < 7)
        {
            CanCraft_BurlapArmor = false;
        }

        if (CanCraft_BurlapArmor == true)
        {
            Inv.sand_resource = Inv.sand_resource - 7;
            Inv.rope_resource = Inv.rope_resource - 7;
            player.damageReduction = 1;
            B_BurlapArmor.SetActive(false);
        }
    }

    public void WoodArmor()
    {
        if (Inv.wood_resource >= 10)
        {
            CanCraft_WoodArmor = true;
        }

        else if (Inv.wood_resource < 10)
        {
            CanCraft_WoodArmor = false;
        }

        if (CanCraft_WoodArmor == true)
        {
            Inv.wood_resource = Inv.wood_resource - 10;
            player.damageReduction = 2;
            B_WoodArmor.SetActive(false);
        }
    }

    public void StoneArmor()
    {
        if (Inv.stone_resource >= 20)
        {
            CanCraft_StoneArmor = true;
        }

        else if (Inv.stone_resource < 20)
        {
            CanCraft_StoneArmor = false;
        }

        if (CanCraft_StoneArmor == true)
        {
            Inv.stone_resource = Inv.stone_resource - 20;
            player.damageReduction = 3;
            B_StoneArmor.SetActive(false);
        } 
    }

    public void MetalArmor()
    {
        if (Inv.iron_resource >= 50)
        {
            CanCraft_MetalArmor = true;
        }

        else if (Inv.iron_resource < 50)
        {
            CanCraft_MetalArmor = false;
        }

        if (CanCraft_MetalArmor == true)
        {
            Inv.iron_resource = Inv.iron_resource - 50;
            player.damageReduction = 5;
            B_MetalArmor.SetActive(false);
        }
    }

    public void SpikeTrap()
    {
        if (Inv.iron_resource >= 15)
        {
            CanCraft_SpikeTrap = true;
        }

        else if (Inv.iron_resource < 15)
        {
            CanCraft_SpikeTrap = false;
        }

        if (CanCraft_SpikeTrap == true)
        {
            Inv.iron_resource = Inv.iron_resource - 15;
            Inv.craftedSpikeTrap++;
            belt.AddItem(item_SpikeTrap);
        }
    }

    public void BearTrap()
    {
        if (Inv.iron_resource >= 25)
        {
            CanCraft_BearTrap = true;
        }

        else if (Inv.iron_resource < 25)
        {
            CanCraft_BearTrap = false;
        }

        if (CanCraft_BearTrap == true)
        {
            Inv.iron_resource = Inv.iron_resource - 25;
            Inv.craftedBearTrap++;
            belt.AddItem(item_BearTrap);
        }
    }

    #endregion

}
