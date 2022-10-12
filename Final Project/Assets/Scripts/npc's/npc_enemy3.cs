using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npc_enemy3 : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player_target;
    public GameObject rifle;
    Animator animator;
    private int health = 100;
    
    public int Health
    {
        get { return health; }   // get method
        set { health = value; }  // set method
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
            rifle.SetActive(true);
        }

        if (health == 0)
        {
            print("enemy3 you are dead");
            agent.enabled = false;
            rifle.SetActive(false);
            animator.SetInteger("state", 2);
        }
    }
}