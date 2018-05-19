using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyV2 : MonoBehaviour
{
    EnemyTargetManager targetManager;
	// Use this for initialization
	void Start ()
    {
        targetManager = FindObjectOfType<EnemyTargetManager>();

        if (targetManager != null)
        {
            targetManager.AddAllTargets();
        }
	}

    void OnDestroy()
    {
        if (targetManager != null)
        {
            targetManager.RemoveTarget(transform);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
