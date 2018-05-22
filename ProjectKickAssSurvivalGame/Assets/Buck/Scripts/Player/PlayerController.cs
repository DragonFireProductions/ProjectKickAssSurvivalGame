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
    float jumpPower; 

    [SerializeField]
    float loseStamina;
    [SerializeField]
    float recoverStamina;

    float recoverStamineTimer;

    float loseStaminaTimer;

    [Header("UnitySettings")]
    EnemyTargetManager enemyTM;
    Rigidbody playerRB;
    Vector3 movement;
    float camRayLength = 100f;
    int floorMask;

    bool isFalling;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRB = GetComponent<Rigidbody>();
        enemyTM = FindObjectOfType<EnemyTargetManager>();
        health.SetValues();
        Stamina.SetValues();
    }

    void Start()
    {
        enemyTM.AddTarget(transform);
    }


    void FixedUpdate()
    {
        //Move Left/Right
        float moveX = Input.GetAxisRaw("Horizontal");

        //Move Forward/Backward
        float moveZ = Input.GetAxisRaw("Vertical");

        PlayerMovement(moveX, moveZ);
        PlayerTurning();
        CheckJumpStatus();
    }

    void OnCollisionStay()
    {
        isFalling = false;
    }

    void CheckJumpStatus()
    {
        if (Input.GetKey(KeyCode.Space) && !isFalling)
        {
            playerRB.velocity = new Vector3(0f, jumpPower, 0f);
            isFalling = true;
        }
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
        //NEEDS TO SUBTRACT ONLY WHEN MOVINGS
        if (Stamina.CurValue >= 0)
        {
            //This is the functionallit for sprinting
            if (Input.GetKey(KeyCode.LeftShift))
            {
                loseStaminaTimer += Time.deltaTime;

                if (Stamina.CurValue <= 0)
                {
                    movement = movement.normalized * walkSpeed * Time.deltaTime;
                }
                else
                {
                    movement = movement.normalized * runSpeed * Time.deltaTime;
                }

                playerRB.MovePosition(transform.position + movement);

                if (loseStaminaTimer >= loseStamina)
                {
                    Stamina.CurValue -= 1;
                    loseStaminaTimer = 0;
                }
            }
            else
            {
                recoverStamineTimer += Time.deltaTime;

                if (Stamina.CurValue < Stamina.MaxValue)
                {
                    if (recoverStamineTimer >= recoverStamina)
                    {
                        Stamina.CurValue += 1;
                        recoverStamineTimer = 0;
                    }
                }
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
        enemyTM.RemoveTarget(transform);
    }
}
