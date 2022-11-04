using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerQueueGameHandler : MonoBehaviour
{
    private waitingQueue waitingQ;
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> waitingQueuePositionList = new List<Vector3>();
        Vector3 firstPosition = new Vector3(10, 0.5f, 3); //public Vector3(float x, float y, float z)
        float positionSize = 10f;

        for (int i = 0; i < 5; i++)
        {
            waitingQueuePositionList.Add(firstPosition + new Vector3(0, 0, -1) * positionSize * i);
            //back Shorthand for writing Vector3(0, 0, -1).
        }

        waitingQ = new waitingQueue(waitingQueuePositionList, positionSize);
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("GetInLine"))
        {
            if(waitingQ.CanAddCustomer())
            {
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.enabled = true;

            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
