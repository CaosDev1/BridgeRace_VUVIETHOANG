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

    public bool isDestination => Vector3.Distance(destination, transform.position) < 0.1f;
    private IState currentState;
    public Vector3 destination;

    protected override void Start()
    {
        base.Start();
        ChangeState(new PatrolState());
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    public void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 15f, brickLayer);

        if(colliders.Length != 0 ) 
        {
            for (int i = colliders.Length - 1; i >= 0; i--)
            {
                if (colliders[i].gameObject.GetComponent<Brick>().colorData == colorPlayerData)
                {
                    destination = colliders[i].transform.position;
                    break;
                }
            }
        }
        
    }

    public void MoveTarget(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 15f);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
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
