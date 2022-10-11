using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npc_enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player_target;
    Animator animator;
    private int health = 100; 

    public int Health 
    {
        get { return health; }   // get method
        set { health = value; print("you'r health is" + health); }  // set method
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.enabled = false;
    }

    void Update()
    {
        if (agent.enabled)
            agent.SetDestination(player_target.transform.position);

        if (animator.GetInteger("state") == 1)
        {
            agent.enabled = true;
        }

        if(health == 0)
        {
            agent.enabled = false;
            animator.SetInteger("state", 2);
        }
    }
}