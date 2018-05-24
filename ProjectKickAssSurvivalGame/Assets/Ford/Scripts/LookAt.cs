using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Canvas pfiCanvas;

    bool inRange;

    void Start ()
    {
        
    }

    private void Awake()
    {
        pfiCanvas = GetComponentInChildren<Canvas>();
        pfiCanvas.enabled = false;
    }


    void Update ()
    {
        LookAtCamera();
    }

    void LookAtCamera()
    {
        if (pfiCanvas.enabled)
        {
            pfiCanvas.transform.rotation = Camera.main.transform.rotation;
        }
        else
            return;
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            inRange = true;
            pfiCanvas.enabled = true;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            inRange = false;
            pfiCanvas.enabled = false;
        }    
    }
}
