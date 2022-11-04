using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AiBaseController : MonoBehaviour
{
    public static int queueSize = 5;
    [SerializeField] protected AIData aIData;

    List<Vector3> waitingQueuePositionList = new List<Vector3>();
    public Vector3 firstPosition = new Vector3(140, 5f, 100);
    float positionSize = 10f;
    public bool followUpLeftQueue = false;

    public void Awake()
    {
        for (int i = 0; i < queueSize; i++)
        { 
            waitingQueuePositionList.Add(firstPosition + new Vector3(0, 0, 1) * positionSize * i);
        }
    }

    protected Vector3 SomeLocation()
    {
        if (aIData.followAgent == null || followUpLeftQueue == true)
            return firstPosition;

        Vector3 position;
        if (aIData.followAgent != null)
        {
            position = aIData.followAgent.nextPosition;
            for (int i = 0; i < queueSize; i++)
            {
                float distance = Vector3.Distance(position, waitingQueuePositionList[i]);
                if(distance < 1)
                {
                    if(i == (queueSize - 1))
                        return aIData.agent.nextPosition;

                    if (i == 0)
                        followUpLeftQueue = true;

                    return waitingQueuePositionList[i + 1];
                }

            }
        }

        return aIData.agent.nextPosition;
    }
}
