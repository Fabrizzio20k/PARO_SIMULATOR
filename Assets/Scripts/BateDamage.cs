using UnityEngine;

public class BateDamage : MonoBehaviour
{
    public float pushForce = 15f;
    public int damage = 10;
    public float damageCooldown = 1f;

    private float nextDamageTime = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time < nextDamageTime) return;

        if (other.CompareTag("NPC"))
        {
            NPCEnemy npc = other.GetComponent<NPCEnemy>();
            if (npc != null)
            {
                npc.TakeDamage(damage);
                npc.Retroceder(transform.position, pushForce);

                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }

    void Update(){
    }

}




