using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHazard : MonoBehaviour
{
    GameObject player;
    PlayerController playerSpeed;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpeed = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //playerSpeed.walkSpeed -= 2.5f;
            //playerSpeed.runSpeed -= 5;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //playerSpeed.walkSpeed += 2.5f;
            //playerSpeed.runSpeed += 5;
        }
    }
}
