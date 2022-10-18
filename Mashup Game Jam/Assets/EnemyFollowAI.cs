using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowAI : MonoBehaviour
{
    private EnemyAI enemyAI;
    private Rigidbody2D rb;
    private NavMeshAgent agent;

    private GameObject player;

    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();

        player = FindObjectOfType<PlayerController>().gameObject;
    }

    void Update()
    {
        if (enemyAI.active == true)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    void OnCollisionExit2D()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
