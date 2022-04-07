using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float lookRadius = 10f;
    [SerializeField] Transform target;
    CharacterCombat combat;
    
    [Header("Nav Mesh Values")]
    private NavMeshAgent navMeshAgent;
    [SerializeField] Transform[] waypoints;
    private int m_CurrentWaypointIndex;
    [SerializeField] float startWaitTime = 4;
    private float m_WaitTime;
    private float speedWalk = 3;

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        combat = GetComponent<CharacterCombat>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        m_CurrentWaypointIndex = 0;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        m_WaitTime = startWaitTime;

        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius) // If player is within detect radius
        {
            navMeshAgent.SetDestination(target.position); // Move towards target

            if (distance <= navMeshAgent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }
                
                FaceTarget();
            }

        }
        else // Patrol
        {
            Patrolling();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Patrolling()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            //  If the enemy arrives to the waypoint position then wait for a moment and go to the next
            if (m_WaitTime <= 0)
            {
                NextPoint();
                Move(speedWalk);
                m_WaitTime = startWaitTime;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }

    public void NextPoint()
    {
        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }

    void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }
    void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }

/*    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Weapon Collision");
            Vector3 moveDirection = transform.position - target.transform.position;
            rigidBody.AddForce(moveDirection.normalized * -8000f, ForceMode.Impulse);
            Debug.Log("Move Direction: " + moveDirection);
        }
    }*/


    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Weapon Collision");
            Debug.Log("Transform Position: " + transform.position);
            Debug.Log("Target Transform Position: " + target.transform.position);

            Vector3 moveDirection = transform.position - target.transform.position;
            rigidBody.AddForce(moveDirection.normalized * 8000f, ForceMode.Impulse);
            //rigidBody.AddForce(rigidBody.velocity * -1, ForceMode.Impulse);
            Debug.Log("Move Direction: " + moveDirection);

            
        }
        /*Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0;

            rb.AddForce(direction.normalized * 10*//* Knockback Strength *//*, ForceMode.Impulse);
        }*/



        /*        if (collision.gameObject.tag == "Weapon")
                {
                    Debug.Log("Weapon Collision");
                    Vector3 moveDirection = transform.position - target.transform.position;
                    rigidBody.AddForce(moveDirection.normalized * -8000f, ForceMode.Impulse);
                    Debug.Log("Move Direction: " + moveDirection);

                }*/
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
