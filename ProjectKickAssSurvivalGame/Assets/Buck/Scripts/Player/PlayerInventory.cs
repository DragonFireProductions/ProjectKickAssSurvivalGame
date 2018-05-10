using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Resources")]

    [HideInInspector]
    public int wood;
    [HideInInspector]
    public int stone;
    [HideInInspector]
    public int iron;
    [HideInInspector]
    public int coin;

    void OnTriggerEnter(Collider resource)
    {
        if (resource.tag == "Wood_Resource")
        {
            wood++;
            Destroy(resource.gameObject);
        }

        if (resource.tag == "Coin_Resource")
        {
            coin++;
            Destroy(resource.gameObject);
        }
    }

    void OntriggerEnter(Collider resource)
    {
        if (resource.tag == "Wood_Resource")
        {
            wood++;
            Destroy(resource.gameObject);
        }

        if (resource.tag == "Coin_Resource")
        {
            coin++;
            Destroy(resource.gameObject);
        }
    }
}
