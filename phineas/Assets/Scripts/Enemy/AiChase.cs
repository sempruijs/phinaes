using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float gridSize = 0.2f;
    public float distanceBetween = 1f;

    private Vector3 targetPosition;
    private float distance;

    SceneManager sceneManager;

    void Update()
    {
        //get the distance between the player 
        distance = Vector2.Distance(transform.position, player.transform.position);

        // if the player falls whithin distance start moving
        if (distance < distanceBetween)
        {
            MoveTowardsPlayer();
        }
    }

    // Single method to handle both direction checking and movement
    void MoveTowardsPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        // Check the dominant direction and set the movement target
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Move left or right
            targetPosition = direction.x > 0 ?
                transform.position + Vector3.right * gridSize :
                transform.position + Vector3.left * gridSize;
        }
        else
        {
            // Move up or down
            targetPosition = direction.y > 0 ?
                transform.position + Vector3.up * gridSize :
                transform.position + Vector3.down * gridSize;
        }

        // Move the enemy directly towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            // Do something with the enemy object
        }
    }


}
