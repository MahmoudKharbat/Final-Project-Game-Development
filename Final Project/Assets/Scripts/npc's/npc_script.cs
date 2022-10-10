using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npc_script: MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject target;
    public GameObject currNpc;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (agent.enabled)
            agent.SetDestination(target.transform.position);
        if (animator.GetInteger("state") == 1)
        {
            agent.enabled = true;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (target.gameObject == other.gameObject)
         {
             Destroy(currNpc);
         }
    }
}