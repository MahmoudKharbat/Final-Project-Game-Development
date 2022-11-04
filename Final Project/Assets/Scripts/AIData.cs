using UnityEngine.AI;
using UnityEngine;

[System.Serializable]

public struct AIData
{
    public NavMeshAgent agent;
    public NavMeshAgent followAgent;
    [Range(0, 100)] public float speed;
    [Range(1, 500)] public float walkRadius;
}
