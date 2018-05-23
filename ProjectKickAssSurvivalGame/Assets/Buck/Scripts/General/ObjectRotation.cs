using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Currently this script is being used on
/// 2D sprites, however in the future this can be converted
/// Into 3d models
/// </summary>



public class ObjectRotation : MonoBehaviour
{
    Transform player;

    [SerializeField]
    float distanceFromPlayer;

    [SerializeField]
    float vaccumSpeed;

    Vector3 newPosition = new Vector3();
    Vector3 curPosition = new Vector3();

    public float rotationSpeed;
    public float height = 0.5f;
    public float frequency = 1f;

    bool canFloat = true;

    void Start()
    {
        curPosition = transform.position;
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update ()
    {
        DoTheShit();
    }

    void DoTheShit()
    {
        if (canFloat && Vector3.Distance(player.position, transform.position) >= distanceFromPlayer)
        {
            newPosition = curPosition;
            newPosition.y = curPosition.y + Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * height;
            transform.position = newPosition;
            Rotate();
        }
        else if (Vector3.Distance(player.position, transform.position) <= distanceFromPlayer)
        {
            canFloat = false;
            transform.position = Vector3.MoveTowards(transform.position, player.position, vaccumSpeed * Time.deltaTime);

            newPosition = transform.position;
            curPosition = newPosition;
        }
        else
        {
            canFloat = true;

            newPosition = transform.position;
            curPosition = newPosition;
        }
    }

    void Rotate()
    {
        gameObject.transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f), Space.World);
    }

}
