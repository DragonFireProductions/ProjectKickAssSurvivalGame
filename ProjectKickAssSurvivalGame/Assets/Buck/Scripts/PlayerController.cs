using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //NEED TO CREATE A SPRINT TIMER AND METER

    [SerializeField]
    float walkSpeed;

    [SerializeField]
    float runSpeed;

    [SerializeField]
    int maxHealth;

    int curHealth;

	// Use this for initialization
	void Start ()
    {
        curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {

        PlayerMovement();
	}

    void PlayerMovement()
    {
        //Move Left/Right
        float moveX = Input.GetAxisRaw("Horizontal");

        //Move Forward/Backward
        float moveZ = Input.GetAxisRaw("Vertical");

        if (moveX != 0)
        {
            //Player walk
            transform.Translate(moveX * walkSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Player sprint
                transform.Translate(moveX * runSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
            }

        }

        if (moveZ != 0)
        {
            //Move game object Forward or Backward by walkSpeed amount
            transform.Translate(0.0f, 0.0f, moveZ * walkSpeed * Time.deltaTime, Space.World);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Player sprint
                transform.Translate(0.0f, 0.0f, moveZ * runSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
