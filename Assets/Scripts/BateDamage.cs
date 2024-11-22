using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;
using System;

public class BateDamage : MonoBehaviour
{
    public float pushForce = 5f;
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
                Vector3 pushDirection = (other.transform.position - transform.position).normalized;

                npc.TakeDamage(damage, pushDirection, pushForce);

                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }

    void Update(){
    }

}




