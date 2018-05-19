using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetManager : MonoBehaviour
{
    public List<Transform> targets;

    public List<Transform> GetTargets()
    {
        return targets;
    }

    public Transform FindClosestTarget()
    {
        
        Transform closestTarget = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (Transform target in targets)
        {
            Vector3 diff = transform.position - position;
            float curDistance = diff.magnitude;
            if (curDistance < distance)
            {
                closestTarget = target;
                distance = curDistance;
            }
        }
        return closestTarget;
    }

    public void AddAllTargets()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //GameObject fire = GameObject.FindGameObjectWithTag("Fire");
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        //GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

        AddTarget(player.transform);

        if (targets.Contains(player.transform))
        {
            Debug.Log("Got player");
        }
        //AddTarget(fire.transform);

        //if (fire == null)
        //    return;

        //if (walls == null)
        //    return;

        foreach (GameObject turret in turrets)
        {
            AddTarget(turret.transform);

            if (turrets == null)
                return;
            else
                Debug.Log("Got" + turrets.Length);
        }

        //foreach (GameObject wall in walls)
        //{
        //    AddTarget(wall.transform);

        //    if (walls == null)
        //        return;
        //}
    }

    public void AddTarget(Transform target)
    {
        targets.Add(target);
    }

    public void RemoveTarget(Transform target)
    {
        //Change this to an int that tracks place in list
        //if (targets.Count > 0)
        //{
        //    targets.RemoveAt(0);
        //}
    }
}
