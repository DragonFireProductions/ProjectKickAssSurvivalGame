using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float walkSpeed;

    [SerializeField]
    float runSpeed;

    [SerializeField]
    float rotateSpeed;

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        //Move Left/Right
        float moveX = Input.GetAxisRaw("Horizontal");

        //Move Forward/Backward
        float moveZ = Input.GetAxisRaw("Vertical");

        //Move Character Left/Right
        float mouseX = Input.GetAxisRaw("Mouse X");

        if (moveX != 0)
        {
            //Player walk
            transform.Translate(moveX * walkSpeed * Time.deltaTime, 0.0f, 0.0f, Space.Self);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Player sprint
                transform.Translate(moveX * runSpeed * Time.deltaTime, 0.0f, 0.0f, Space.Self);
            }

        }

        if (moveZ != 0)
        {
            //Move game object Forward or Backward by walkSpeed amount
            transform.Translate(0.0f, 0.0f, moveZ * walkSpeed * Time.deltaTime, Space.Self);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Player sprint
                transform.Translate(0.0f, 0.0f, moveZ * runSpeed * Time.deltaTime, Space.Self);
            }
        }

        if (mouseX != 0)
        {
            //Rotate the player by rotate speed then the mouse is moved
            transform.Rotate(0.0f, mouseX * rotateSpeed * Time.deltaTime, 0.0f, Space.World);
            transform.LookAt(transform.forward + transform.position);
        }
    }
}
