using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NPCEnemy : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private HealthHandler healthHandler;
    private float attackCooldown = 2f;
    private float attackTimer = 1f;
    private int life = 20;
    private Globals globals;

    private Animator animator;
    private Renderer[] renderers; // Para cambiar el color del prefab
    private Rigidbody rb; // Para aplicar empuje
    private bool isHit = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        healthHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        renderers = GetComponentsInChildren<Renderer>();
        rb = GetComponent<Rigidbody>();
        globals = GameObject.Find("Globals").GetComponent<Globals>();
    }

    void Update()
    {
        if (life <= 0) return;

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

    public void TakeDamage(int damage, Vector3 pushDirection, float pushForce)
    {
        if (isHit) return;

        life -= damage;

        // Aplicar empuje al NPC
        if (rb != null)
        {
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }

        // Cambiar a color rojo
        StartCoroutine(FlashRed());

        if (life <= 0)
        {
            globals.addNPC(-1);
            Destroy(gameObject);
        }
    }

    private IEnumerator FlashRed()
    {
        isHit = true;

        foreach (var renderer in renderers)
        {
            renderer.material.color = Color.red;
        }

        yield return new WaitForSeconds(0.2f);

        foreach (var renderer in renderers)
        {
            renderer.material.color = Color.white;
        }

        isHit = false;
    }
}
