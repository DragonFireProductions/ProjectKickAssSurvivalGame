using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int wood_resource;
    private int stone_resource;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Wood_Resource")
        {
            wood_resource++;
        }

        if (gameObject.tag == "Stone_Resource")
        {
            stone_resource++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Wood_Resource")
        {
            wood_resource++;
        }

        if (gameObject.tag == "Stone_Resource")
        {
            stone_resource++;
        }
    }

    //public WoodResource()
    //{
    //    return wood_resource;
    //}

}
