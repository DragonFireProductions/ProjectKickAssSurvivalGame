using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float walkSpeed;

    [SerializeField]
    float runSpeed;

    Rigidbody playerRB;

    Vector3 movement;

    float camRayLength = 100f;

    int floorMask;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Move Left/Right
        float moveX = Input.GetAxisRaw("Horizontal");

        //Move Forward/Backward
        float moveZ = Input.GetAxisRaw("Vertical");

        PlayerMove(moveX, moveZ);
        PlayerTurning();
    }

    void PlayerMove(float x, float z)
    {
        //This is the functionallity for walking
        movement.Set(x, 0f, z);

        movement = movement.normalized * walkSpeed * Time.deltaTime;

        playerRB.MovePosition(transform.position + movement);

        //This is the functionallit for sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement = movement.normalized * runSpeed * Time.deltaTime;

            playerRB.MovePosition(transform.position + movement);
        }
    }

    void PlayerTurning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRB.MoveRotation(newRotation);
        }
    }
}
