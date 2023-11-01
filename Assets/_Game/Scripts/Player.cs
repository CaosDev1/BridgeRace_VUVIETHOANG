using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    [Header("Move Info")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    private Vector3 moveVector;
    private bool canMove = true;

    //private bool isJoystick;
    //[SerializeField] private Canvas inputCanvas;
    //[SerializeField] private CharacterController controller;

    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }

    

    //private void EnnableJoystickInput()
    //{
    //    isJoystick = true;
    //    inputCanvas.gameObject.SetActive(true);
    //}

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
        moveVector.z = joystick.Vertical * moveSpeed * Time.deltaTime;

        if (joystick.Direction.y <= -0.1f)
        {
            canMove = true;
        }

        //rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }
        else if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            return;
        }
        if (canMove)
        {
            rb.MovePosition(rb.position + moveVector);

        }

        //if (isJoystick)
        //{
        //    Vector3 movementDirection = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);

        //    if (joystick.Direction.y <= -0.1f)
        //    {
        //        canMove = true;
        //    }

        //    if (canMove)
        //    {
        //        controller.SimpleMove(movementDirection * moveSpeed);

        //    }

        //    if (movementDirection.sqrMagnitude <= 0)
        //    {
        //        return;
        //    }

        //    Vector3 targetDirection = Vector3.RotateTowards(controller.transform.forward, movementDirection, rotateSpeed * Time.deltaTime, 0.0f);
        //    controller.transform.rotation = Quaternion.LookRotation(targetDirection);
        //}
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstString.BRICK_TAG))
        {
            Brick brick = other.GetComponent<Brick>();
            if (colorPlayerData == brick.colorData)
            {
                AddBrick();
            }
        }

        if (other.CompareTag(ConstString.STAIR_TAG))
        {
            Stair stair = other.GetComponent<Stair>();
            if (playerBrickList.Count <= 0 && !stair.isCollect)
            {
                canMove = false;
            }

            if (colorPlayerData != stair.stairColorData)
            {
                canMove = false;
            }
        }
    }
}
