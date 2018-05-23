using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region//Resources
    
    [HideInInspector] public int wood_resource, stone_resource, coin_resource, iron_resource, grass_resource, sand_resource, flint_resource,
    stick_resource, honey_resource, hide_resource, rope_resource, leather_resource, charcoal_resource;

    #endregion

    #region//Crafted Item Count

    [HideInInspector] public int craftedBurlapWall, craftedWoodFence, craftedStoneFence, craftedMetalFence, craftedWoodTurret, craftedStoneTurret, craftedMetalTurret, craftedSpikeTrap, craftedBearTrap;

    #endregion

    #region//Resource Texts

    public Text Text_WoodResource;
    public Text Text_StoneResource;
    public Text Text_IronResource;
    public Text Text_SandResource;
    public Text Text_CoinResource;
    public Text Text_GrassResource;
    public Text Text_FlintResource;
    public Text Text_StickResource;
    public Text Text_HoneyResource;
    public Text Text_HideResource;
    public Text Text_LeatherResource;
    public Text Text_RopeResource;
    public Text Text_CharcoalResource;
    public Text Text_BurlapWall;
    public Text Text_WoodFence;
    public Text Text_StoneFence;
    public Text Text_MetalFence;
    public Text Text_WoodTurret;
    public Text Text_StoneTurret;
    public Text Text_MetalTurret;
    public Text Text_SpikeTrap;
    public Text Text_BearTrap;

    #endregion

    private void Start()
    {
        Text_WoodResource.text = "0" + wood_resource;
        Text_StoneResource.text = "0" + stone_resource;
        Text_IronResource.text = "0" + iron_resource;
        Text_SandResource.text = "0" + sand_resource;
        Text_CoinResource.text = "0" + coin_resource;
        Text_GrassResource.text = "0" + grass_resource;
        Text_FlintResource.text = "0" + flint_resource;
        Text_StickResource.text = "0" + stick_resource;
        Text_HoneyResource.text = "0" + honey_resource;
        Text_HideResource.text = "0" + hide_resource;
        Text_LeatherResource.text = "0" + leather_resource;
        Text_RopeResource.text = "0" + rope_resource;
        Text_CharcoalResource.text = "0" + charcoal_resource;
        Text_BurlapWall.text = "0" + craftedBurlapWall;
        Text_WoodFence.text = "0" + craftedWoodFence;
        Text_StoneFence.text = "0" + craftedStoneFence;
        Text_MetalFence.text = "0" + craftedMetalFence;
        Text_WoodTurret.text = "0" + craftedWoodTurret;
        Text_StoneTurret.text = "0" + craftedStoneTurret;
        Text_MetalTurret.text = "0" + craftedMetalTurret;
        Text_SpikeTrap.text = "0" + craftedSpikeTrap;
        Text_BearTrap.text = "0" + craftedBearTrap;
    }

    private void Update()
    {
        Text_WoodResource.text = "" + wood_resource;
        Text_StoneResource.text = "" + stone_resource;
        Text_IronResource.text = "" + iron_resource;
        Text_SandResource.text = "" + sand_resource;
        Text_CoinResource.text = "" + coin_resource;
        Text_GrassResource.text = "" + grass_resource;
        Text_FlintResource.text = "" + flint_resource;
        Text_StickResource.text = "" + stick_resource;
        Text_HoneyResource.text = "" + honey_resource;
        Text_HideResource.text = "" + hide_resource;
        Text_LeatherResource.text = "" + leather_resource;
        Text_RopeResource.text = "" + rope_resource;
        Text_CharcoalResource.text = "" + charcoal_resource;
        Text_BurlapWall.text = "" + craftedBurlapWall;
        Text_WoodFence.text = "" + craftedWoodFence;
        Text_StoneFence.text = "" + craftedStoneFence;
        Text_MetalFence.text = "" + craftedMetalFence;
        Text_WoodTurret.text = "" + craftedWoodTurret;
        Text_StoneTurret.text = "" + craftedStoneTurret;
        Text_MetalTurret.text = "" + craftedMetalTurret;
        Text_SpikeTrap.text = "" + craftedSpikeTrap;
        Text_BearTrap.text = "" + craftedBearTrap;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wood_Resource")
        {
            wood_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Stone_Resource")
        {
            stone_resource++;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Coin_Resource")
        {
            coin_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Iron_Resource")
        {
            iron_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Grass_Resource")
        {
            grass_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Sand_Resource")
        {
            sand_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Flint_Resource")
        {
            flint_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Stick_Resource")
        {
            stick_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Honey_Resource")
        {
            honey_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Hide_Resource")
        {
            hide_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Rope_Resource")
        {
           rope_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Leather_Resource")
        {
            leather_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Charcoal_Resource")
        {
            charcoal_resource++;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Wood_Resource")
        {
            wood_resource++;
            Destroy(other.gameObject);
        }

        if (gameObject.tag == "Stone_Resource")
        {
            stone_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Coin_Resource")
        {
            coin_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Iron_Resource")
        {
            iron_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Grass_Resource")
        {
            grass_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Sand_Resource")
        {
            sand_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Flint_Resource")
        {
            flint_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Stick_Resource")
        {
            stick_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Honey_Resource")
        {
            honey_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Hide_Resource")
        {
            hide_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Rope_Resource")
        {
            rope_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Leather_Resource")
        {
            leather_resource++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Charcoal_Resource")
        {
            charcoal_resource++;
            Destroy(other.gameObject);
        }
    }


}
