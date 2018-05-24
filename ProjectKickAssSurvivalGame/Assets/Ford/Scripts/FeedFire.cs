using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedFire : MonoBehaviour
{
    FireManager fire;
    Inventory inv;
	
	void Start ()
    {
        fire = FindObjectOfType<FireManager>();
        inv = FindObjectOfType<Inventory>();
	}
	
	
	void Update ()
    {
		
	}

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && inv.wood_resource >= 1)
        {
            inv.wood_resource -= 1;
            fire.health.CurValue += 1;
        }
    }
}
