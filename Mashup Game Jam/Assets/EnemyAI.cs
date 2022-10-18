using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int damage;
    public float attackCooldown;

    public bool active = false;
    private bool canAttack = true;

    private Rigidbody2D rb;
    private NavMeshAgent agent;

    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = FindObjectOfType<PlayerController>().gameObject;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        // Attack the player if the attack cooldown is over
        if (other.gameObject.tag == "Player" && canAttack)
        {
            other.gameObject.GetComponent<PlayerController>().DamagePlayer(damage);
            canAttack = false;
            Invoke("AttackCooldownOver", attackCooldown);
        }
    }

    private void AttackCooldownOver()
    {
        canAttack = true;
    }
}
