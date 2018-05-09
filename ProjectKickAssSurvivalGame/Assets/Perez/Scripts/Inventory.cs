using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int wood_resource, stone_resource, coin_resource;

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
    }
}
