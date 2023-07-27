using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private float gravityScale = 1.0f;
    [SerializeField]
    private float jumpHeight = 5.0f;

    private Vector3 playerVelocity;
    private float gravity = -9.8f;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        playerVelocity.y += gravity * Time.deltaTime;

        Move();

        if (characterController.isGrounded)
        {
            Jump();

            if (playerVelocity.y < 0)
            {
                playerVelocity.y = -2.0f;
            }
        }
    }

    private void Move()
    {
       float xMove = Input.GetAxis("Horizontal");
       float zMove = Input.GetAxis("Vertical");

        /*Vector3 moveDirection = (transform.right * xMove) + (transform.forward * zMove);
        moveDirection.y += gravity * Time.deltaTime * gravityScale;
        moveDirection *= moveSpeed * Time.deltaTime;
       
        Debug.Log(moveDirection);
        characterController.Move(moveDirection);*/

        Vector3 moveDirection = new(xMove, gravity * Time.deltaTime, zMove);

        characterController.Move(transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerVelocity.y *= jumpHeight;
        }
    }
}
