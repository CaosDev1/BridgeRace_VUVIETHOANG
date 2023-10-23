using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float moveSpeed;

    public List<Transform> playerBrickList;
    [SerializeField] private Transform playerBrickPrefab;
    [SerializeField] private Transform brickHolder;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            //transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
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
}
