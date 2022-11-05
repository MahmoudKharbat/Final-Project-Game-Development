using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class NPC_Queue : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    public GameObject dest;
    public GameObject target;
    public GameObject currNpc;

    public int wait;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        StartCoroutine(waitBeforeWalk(wait));
    }

    // Update is called once per frame
    void Update()
    {        
        if (animator.GetInteger("state") == 1)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (dest.gameObject == other.gameObject)
        {
            animator.SetTrigger("arrivedQueue");
        }
        if (target.gameObject == other.gameObject)
        {
            Destroy(currNpc);
        }
    }

    IEnumerator waitBeforeWalk(int wait)
    {
        animator.SetTrigger("stand");
        yield return new WaitForSeconds(wait + 0f);
        animator.SetTrigger("goToQueue");
        agent.SetDestination(dest.transform.position);
    }
}
