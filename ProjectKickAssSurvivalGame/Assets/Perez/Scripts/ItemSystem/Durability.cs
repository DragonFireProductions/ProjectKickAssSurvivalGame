using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
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
		
	}
}
