using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private bool CanCraft_WoodFence, CanCraft_StoneFence;

    private Inventory Inv;

    [SerializeField] private GameObject G_WoodFence, G_StoneFence;

    private void Start()
    {
        Inv = GetComponent<Inventory>();

        CanCraft_WoodFence = false;
        CanCraft_StoneFence = false;
    }

    // Update is called once per frame
    void Update ()
    {
        WoodFence();
        StoneFence();
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
                Instantiate(G_WoodFence, transform.position + new Vector3(0,0,5), transform.rotation);
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
                Instantiate(G_StoneFence, transform.position + new Vector3(0, 0, 5), transform.rotation);
                Inv.stone_resource--;
            }
        }

        if (Inv.stone_resource <= 0)
        {
            CanCraft_StoneFence = false;
        }
    }
}
