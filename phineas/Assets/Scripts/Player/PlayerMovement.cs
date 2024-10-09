using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement
    private Vector3 movement;

    void Update()
    {
        GetInput();
        Move();
    }

    void GetInput()
    {
        movement = Vector3.zero; // Reset movement vector

        // Check for vertical input (W/S)
        if (Input.GetKey(KeyCode.W)) // Move up
        {
            movement = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S)) // Move down
        {
            movement = Vector3.down;
        }

        // Check for horizontal input (A/D)
        else if (Input.GetKey(KeyCode.A)) // Move left
        {
            movement = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D)) // Move right
        {
            movement = Vector3.right;
        }
    }

    void Move()
    {
        transform.position += movement * moveSpeed * Time.deltaTime; // Apply movement based on input
    }
}