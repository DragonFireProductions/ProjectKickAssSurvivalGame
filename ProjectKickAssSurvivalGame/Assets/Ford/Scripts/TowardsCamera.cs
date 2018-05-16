using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardsCamera : MonoBehaviour
{
    Transform cam;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(cam);
    }
}
