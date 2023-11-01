using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    Rigidbody body;
    float horizontal;
    float vertical;
    public float jumpForce = 2.0f;
    bool isJumping = false;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public Transform cameraTransform;
    public float movementSpeed = 5.0f;

    public float gravity = -9.81f; // Add this line

    void Start()
    {
        body = GetComponent<Rigidbody>();
       
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 direction = forward * vertical + right * horizontal;

        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed;

        body.MovePosition(movement);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (isJumping)
        {
            body.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isJumping = false;
        }

        body.AddForce(new Vector3(0, gravity, 0), ForceMode.Acceleration); // Add this line
    }
}