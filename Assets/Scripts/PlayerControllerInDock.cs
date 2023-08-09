using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInDock : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed = 1.0f; // Added rotation speed

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Additional rotation input
        if (horizontalInput != 0)
        {
            RotatePlayer(horizontalInput);
        }
    }

    private void MovePlayer()
    {
        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.y = 0f; // Ensure no vertical movement

        // Calculate the target velocity based on the moveDirection and desired speed
        Vector3 targetVelocity = moveDirection.normalized * moveSpeed;

        // Calculate the change in velocity required to reach the target velocity in one fixed timestep
        Vector3 velocityChange = (targetVelocity - rb.velocity);

        // Apply the calculated velocity change to the rigidbody
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void RotatePlayer(float direction)
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        eulerRotation.y += direction * rotationSpeed;
        Quaternion newRotation = Quaternion.Euler(eulerRotation);
        transform.rotation = newRotation;
    }
}