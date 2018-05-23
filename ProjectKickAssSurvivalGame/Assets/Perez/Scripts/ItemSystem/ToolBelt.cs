using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBelt : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];

    public Item[] items = new Item[numItemSlots];
    
    public const int numItemSlots = 9;

    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    private void Update()
    {
        Slot0(items[0]);
        Slot1(items[1]);
        Slot2(items[2]);
        Slot3(items[3]);
        Slot4(items[4]);
        Slot5(items[5]);
        Slot6(items[6]);
        Slot7(items[7]);
        Slot8(items[8]);
    }

    public void Slot0(Item itemToSpawn)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Item i;
            i = itemToSpawn;

            if (i == null)
            {
                return;
            }

            Instantiate(i.gameobject, transform.position, transform.rotation);
            RemoveItem(i);
        }
    }

    public void Slot1(Item itemToSpawn)
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Item i;
            i = itemToSpawn;

            if (i == null)
            {
                return;
            }

            Instantiate(i.gameobject, transform.position, transform.rotation);
            RemoveItem(i);
        }
    }

    public void Slot2(Item itemToSpawn)
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Item i;
            i = itemToSpawn;

            if (i == null)
            {
                return;
            }

            Instantiate(i.gameobject, transform.position, transform.rotation);
            RemoveItem(i);
        }
    }

    public void Slot3(Item itemToSpawn)
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Item i;
            i = itemToSpawn;

            if (i == null)
            {
                return;
            }

            Instantiate(i.gameobject, transform.position, transform.rotation);
            RemoveItem(i);
        }
    }

    public void Slot4(Item itemToSpawn)
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Item i;
            i = itemToSpawn;

            if (i == null)
            {
                return;
            }

            Instantiate(i.gameobject, transform.position, transform.rotation);
            RemoveItem(i);
        }
    }

    public void Slot5(Item itemToSpawn)
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Item i;
            i = itemToSpawn;

            if (i == null)
            {
                return;
            }

            Instantiate(i.gameobject, transform.position, transform.rotation);
            RemoveItem(i);
        }
    }

    public void Slot6(Item itemToSpawn)
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Item i;
            i = itemToSpawn;

            if (i == null)
            {
                return;
            }

            Instantiate(i.gameobject, transform.position, transform.rotation);
            RemoveItem(i);
        }
    }

    public void Slot7(Item itemToSpawn)
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Item i;
            i = itemToSpawn;

            if (i == null)
            {
                return;
            }

            Instantiate(i.gameobject, transform.position, transform.rotation);
            RemoveItem(i);
        }
    }

    public void Slot8(Item itemToSpawn)
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Item i;
            i = itemToSpawn;

            if (i == null)
            {
                return;
            }

            Instantiate(i.gameobject, transform.position, transform.rotation);
            RemoveItem(i);
        }
    }
}