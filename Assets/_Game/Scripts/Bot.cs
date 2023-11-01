using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] protected Vector3 movePoint;


    private void Update()
    {
        
        agent.SetDestination(movePoint);
    }
}
    
