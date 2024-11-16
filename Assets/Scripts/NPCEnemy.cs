using UnityEngine;
using UnityEngine.AI;

public class NPCEnemy : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private HealthHandler healthHandler;
    private float attackCooldown = 2f;
    private float attackTimer = 1f;

    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        healthHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        agent.destination = target.position;

        if (Vector3.Distance(transform.position, target.position) < 1.9f)
        {
            agent.isStopped = true;
            animator.SetBool("IsAttacking", true);

            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                healthHandler.DecreaseHealth(2);
                attackTimer = attackCooldown;
            }
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            agent.isStopped = false;
            attackTimer = 1f;
        }
    }
}
