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
    private bool isHit = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        healthHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        renderers = GetComponentsInChildren<Renderer>();
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
                healthHandler.DecreaseHealth(5);
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

    public void TakeDamage(int damage)
    {
        if (isHit) return;

        life -= damage;


        // Cambiar a color rojo
        StartCoroutine(FlashRed());

        if (life <= 0)
        {
            globals.addNPC(-1);
            globals.killNPC();
            Destroy(gameObject);
        }
    }

    public void Retroceder(Vector3 playerPosition, float pushForce)
    {
        // Calculamos la dirección del retroceso. La dirección es opuesta al jugador.
        Vector3 pushDirection = transform.position - playerPosition; // Dirección hacia el NPC

        // Asegurarse de que el empuje no afecte en el eje Y (sin salto o flotación)
        pushDirection.y = 0; // Esto evitará que el NPC suba o baje

        // Normalizamos la dirección y multiplicamos por la fuerza para aplicar el retroceso
        transform.position += pushDirection.normalized * pushForce * Time.deltaTime;
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
