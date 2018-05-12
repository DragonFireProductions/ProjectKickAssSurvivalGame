using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetManager : MonoBehaviour
{
    public List<GameObject> potentialTargets;

    public List<string> targetTags;

    // Use this for initialization
    void Start ()
    {
        targetTags.Add("Player");
        targetTags.Add("Fire");
        targetTags.Add("Turret");
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateEnemyTargets();
	}

    void UpdateEnemyTargets()
    {

    }
}
