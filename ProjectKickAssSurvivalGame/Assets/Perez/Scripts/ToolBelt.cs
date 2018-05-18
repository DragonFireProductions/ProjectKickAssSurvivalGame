using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBelt : MonoBehaviour
{
    Inventory Inv;

    Dictionary<Button[], int> craftedItem = new Dictionary<Button[], int>();

    public Button[] toolBeltSlots = new Button[9];

    GameObject playerToolBeltCanvas;
    

    // Use this for initialization
    void Start ()
    {
        Inv = GetComponent<Inventory>();

        playerToolBeltCanvas = GameObject.Find("PlayerToolBelt");
        toolBeltSlots = playerToolBeltCanvas.GetComponentsInChildren<Button>();

        craftedItem.Add(toolBeltSlots, Inv.craftedBurlapWall);
        craftedItem.Add(toolBeltSlots, Inv.craftedWoodFence);
        craftedItem.Add(toolBeltSlots, Inv.craftedStoneFence);
        craftedItem.Add(toolBeltSlots, Inv.craftedMetalFence);
        craftedItem.Add(toolBeltSlots, Inv.craftedWoodFence);
        craftedItem.Add(toolBeltSlots, Inv.craftedBurlapArmor);
        craftedItem.Add(toolBeltSlots, Inv.craftedWoodArmor);
        craftedItem.Add(toolBeltSlots, Inv.craftedStoneArmor);
        craftedItem.Add(toolBeltSlots, Inv.craftedMetalArmor);
        craftedItem.Add(toolBeltSlots, Inv.craftedSpikeTrap);
        craftedItem.Add(toolBeltSlots, Inv.craftedBearTrap);
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < toolBeltSlots.Length; i++)
        {
            
        }
	}
}
