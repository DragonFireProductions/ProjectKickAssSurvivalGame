using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public Transform player;

    [HideInInspector]
    public Transform playerFire;

    NavMeshAgent agent;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerFire = GameObject.FindGameObjectWithTag("Fire").transform;

        LocateTarget();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateTarget();
        Navigation();
	}

    public void LocateTarget()
    {
        target = GameObject.FindGameObjectWithTag("Fire").transform;

        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(target.transform.position);
    }

    public void Navigation()
    {
        RaycastHit hit;

        agent.SetDestination(target.transform.position);

        agent.speed = moveSpeed;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        }
    }

    void UpdateTarget()
    {
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);

        float fireDistance = Vector3.Distance(playerFire.transform.position, transform.position);

        if (target != null)
        {
            if (playerDistance >= fireDistance)
            {
                target = playerFire;
            }

            else if (playerDistance < fireDistance)
            {
                target = player;
            }
        }
    }
}
