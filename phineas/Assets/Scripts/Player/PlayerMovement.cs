using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum Direction
    {
        up,
        down, 
        left, 
        right
    }

    public float moveSpeed = 5f;  // Speed of movement
    public float gridSize = 0.2f; // Size of the grid for smoother movement
    private Vector3 targetPosition;
    private bool isMoving = false;

    private Direction currentDirection;

    private void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (!isMoving)
        {
            GetInput();
        }

        Move();
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.W)) // Move up
        {
            currentDirection = Direction.up;
            targetPosition = transform.position + Vector3.up * gridSize;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S)) // Move down
        {
            currentDirection = Direction.down;
            targetPosition = transform.position + Vector3.down * gridSize;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.A)) // Move left
        {
            currentDirection = Direction.left;
            targetPosition = transform.position + Vector3.left * gridSize;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.D)) // Move right
        {
            currentDirection = Direction.right;
            targetPosition = transform.position + Vector3.right * gridSize;
            isMoving = true;
        }
    }

    void Move()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) <= 0.01f)
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
}
