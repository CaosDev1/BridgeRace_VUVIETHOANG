using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 movePoint;
    [SerializeField] private LayerMask brickLayer;
    private IState currentState;

    private void Update()
    {
        FindTarget();
    }

    private void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 15f, brickLayer);

        if (colliders.Length != 0)
        {
            for (int i = colliders.Length - 1; i >= 0; i--)
            {
                if (colliders[i].gameObject.GetComponent<Brick>().colorData == colorPlayerData)
                {
                    Vector3 destination = colliders[i].transform.position;
                    agent.SetDestination(destination);
                    break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 15f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstString.BRICK_TAG))
        {
            Brick brick = other.GetComponent<Brick>();
            if (colorPlayerData == brick.colorData)
            {
                AddBrick();
                FindTarget();
            }
        }
    }

    public void ChangeState(IState newState)
    {
        if(currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if(currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
} 
