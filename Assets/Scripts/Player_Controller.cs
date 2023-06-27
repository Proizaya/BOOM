using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Varibles

    public float movementSpeed = 5f;
    public float jumpForce = 10;
    public float gravity = 20f;

    public CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    #endregion

    void Start()
    {
    controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    
    {
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
    movement = transform.TransformDirection(movement);
    movement *= movementSpeed;

    if (controller.isGrounded)
    {
        moveDirection =  movement;

        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpForce;
        }
    
    }
    else
    {
        moveDirection.y -= gravity * Time.deltaTime;

    }

    controller.Move(moveDirection * Time.deltaTime);
}



    
}
