using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private float moveSpeed;
    private Vector3 moveVector;
    [SerializeField] private float rotateSpeed;

    public List<Transform> playerBrickList;
    [SerializeField] private Transform playerBrickPrefab;
    [SerializeField] private Transform brickHolder;

    [SerializeField] private LayerMask bridgeLayer;
    [SerializeField] private float raycastDistance;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
        moveVector.z = joystick.Vertical * moveSpeed * Time.deltaTime;
        
        //rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        rb.MovePosition(rb.position + moveVector);
    }

    public void AddBrick()
    {
        int index = playerBrickList.Count;
        
        Transform brickSpawn = Instantiate(playerBrickPrefab, brickHolder);
        playerBrickList.Add(brickSpawn);

        brickSpawn.localPosition =  index * 0.4f * Vector3.up;
    }

    public void RemoveBrick()
    {
        int index = playerBrickList.Count - 1;
        Transform brickSpawn = playerBrickList[index];
        
        if(playerBrickList.Count >= 0)
        {
            playerBrickList.Remove(brickSpawn);
            Destroy(brickSpawn.gameObject);
        }
    }

    public void CheckCollison()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down,out hit, raycastDistance, bridgeLayer))
        {
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - raycastDistance,transform.position.z));
    }

    
}
