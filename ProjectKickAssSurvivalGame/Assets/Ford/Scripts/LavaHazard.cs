using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaHazard : MonoBehaviour
{
    GameObject player;
    PlayerController playerLife;
    public float lTimer;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLife = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            lTimer += Time.deltaTime;

            if (lTimer >= 2f)
            {
                Debug.Log("Lava Damage");
                playerLife.health.CurValue -= 1;
                lTimer = 0;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        lTimer = 0f;
    }
}
