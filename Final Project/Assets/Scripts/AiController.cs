using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class AiController : AiBaseController
{
    public void Start()
    {
        aIData.agent = GetComponent<NavMeshAgent>();

        if (aIData.agent != null)
        {
            aIData.agent.speed = aIData.speed;
            aIData.agent.SetDestination(SomeLocation());
        }
    }

    public void Update()
    {
        if((null == aIData.followAgent) == followUpLeftQueue)
        {
            if (aIData.agent != null && aIData.agent.remainingDistance <= aIData.agent.stoppingDistance)
            {
                Vector3 vector3 = SomeLocation();
                if(vector3 != Vector3.zero)
                {
                    aIData.agent.SetDestination(vector3);
                }
            }
        }
    }
}
