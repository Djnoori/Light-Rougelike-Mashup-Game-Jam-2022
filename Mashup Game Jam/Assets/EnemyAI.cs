using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool active = false;

    protected Rigidbody2D rb;
    protected NavMeshAgent agent;

    protected GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = FindObjectOfType<PlayerController>().gameObject;
    }
}
