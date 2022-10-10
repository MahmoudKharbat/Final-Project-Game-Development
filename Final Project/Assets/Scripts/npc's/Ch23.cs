using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ch23 : MonoBehaviour
{
    private int currTarget = 0;
    private NavMeshAgent agent;
    public GameObject[] targets;
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
            agent.SetDestination(targets[currTarget].transform.position);
    }

    IEnumerator changeState(int op)
    {
        switch (op)
        {
            case 0:// typing
                agent.enabled = true;
                animator.SetInteger("state", 0);
                break;

            case 1:// walking
                agent.enabled = true;
                animator.SetInteger("state", 1);
                break;

                /*
                            case 1: // reach the dest - standing - and then start walking again
                                agent.enabled = false;
                                animator.SetInteger("state", 0);
                                yield return new WaitForSeconds(5f);
                                agent.enabled = true;
                                animator.SetInteger("state", 1);
                                break;
                            case 2: // reach the last dest - destroy
                                Destroy(currNpc);
                                break;*/
        }
        yield return new WaitForSeconds(5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targets[currTarget].gameObject == other.gameObject)
        {
            if (currTarget == 0 || currTarget == 1)
                StartCoroutine(changeState(1));

            if (currTarget == 2)
                StartCoroutine(changeState(2));

            currTarget++;
            currTarget %= targets.Length;
        }
        else
            StartCoroutine(changeState(0));

    }
}