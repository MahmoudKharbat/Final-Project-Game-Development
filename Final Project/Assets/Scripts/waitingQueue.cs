using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;

public class waitingQueue
{
    private List<NavMeshAgent> customerList;
    private List<Vector3> positionList;
    private Vector3 entrancePosition;
    
    public waitingQueue(List<Vector3> positionList, float positionSize)
    {
        this.positionList = positionList;
        entrancePosition = positionList[positionList.Count - 1] + new Vector3(-positionSize, 0, 0);
        
        customerList = new List<NavMeshAgent>();

        //NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
    }

    public bool CanAddCustomer()
    {
        return customerList.Count < positionList.Count;
    }

    public bool AddCustomer(NavMeshAgent customer)
    {
        customerList.Add(customer);
        customer.SetDestination(entrancePosition);
        return true;

    }

    public NavMeshAgent GetFirstInQueue()
    {
        if(customerList.Count == 0) 
            return null;
        NavMeshAgent agent = customerList[0];
        customerList.RemoveAt(0);
        return customerList[0];
    }
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
