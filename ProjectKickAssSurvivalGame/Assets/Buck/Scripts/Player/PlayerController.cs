using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerSetings")]
    public Stat health;
    public Stat Stamina;


    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float runSpeed;

    [SerializeField]
    float loseStamina;
    float staminaTimer;

    [Header("UnitySettings")]
    Rigidbody playerRB;
    Vector3 movement;
    float camRayLength = 100f;
    int floorMask;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRB = GetComponent<Rigidbody>();
        health.SetValues();
        Stamina.SetValues();
    }


    void FixedUpdate()
    {
        //Move Left/Right
        float moveX = Input.GetAxisRaw("Horizontal");

        //Move Forward/Backward
        float moveZ = Input.GetAxisRaw("Vertical");

        PlayerMovement(moveX, moveZ);
        PlayerTurning();
    }

    public void TakeDamage(int damage, Vector3 hitPoint)
    {
        health.CurValue -= damage;

        if (health.CurValue <= 0)
        {

            Die();
        }
    }

    void PlayerMovement(float x, float z)
    {
        //This is the functionallity for walking
        movement.Set(x, 0f, z);

        movement = movement.normalized * walkSpeed * Time.deltaTime;

        playerRB.MovePosition(transform.position + movement);

        //NEED TO COME BACK AND FINISH SPRINTING IMPLEMENTATION
        if (Stamina.CurValue >= 0)
        {
            //This is the functionallit for sprinting
            if (Input.GetKey(KeyCode.LeftShift))
            {
                staminaTimer += Time.deltaTime;

                movement = movement.normalized * runSpeed * Time.deltaTime;

                playerRB.MovePosition(transform.position + movement);

                if (staminaTimer >= loseStamina)
                {
                    Stamina.CurValue -= 1;
                    staminaTimer = 0;
                }
            }
            else
            {
                Stamina.CurValue += 1;
            }
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

    void Die()
    {
        //PLAY DIE ANIMATION
    }
}
