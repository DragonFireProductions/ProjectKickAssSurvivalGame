﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region//Resources_ Public Ints

    public int wood_resource, stone_resource, coin_resource, metal_resource, grass_resource, sand_resource, flint_resource,
    stick_resource, honey_resource, hide_resource, rope_resource, leather_resource, charcoal_resource;

    #endregion


    #region

    public int craftedBurlapWall, craftedWoodFence, craftedStoneFence, craftedMetalFence, craftedWoodTurret, craftedStoneTurret, craftedMetalTurret, 
    craftedBurlapArmor, craftedWoodArmor, craftedStoneArmor, craftedMetalArmor, craftedSpikeTrap, craftedBearTrap;

    #endregion

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

        if (other.gameObject.tag == "Metal_Resource")
        {
            metal_resource++;
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

        if (other.gameObject.tag == "Metal_Resource")
        {
            metal_resource++;
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
