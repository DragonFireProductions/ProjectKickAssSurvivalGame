using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : BaseWeapon
{	
	// Update is called once per frame
	void Update ()
    {
        Fire();
        Reload();
	}
}
