using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float distanceBetween = 1f;

    private float distance;

    SceneManager sceneManager;

    void Update()
    {
        // Get the distance between the enemy and the player
        distance = Vector2.Distance(transform.position, player.transform.position);

        // If the player falls within the distance threshold, start moving towards them
        if (distance < distanceBetween)
        {
            MoveTowardsPlayer();
        }
    }

    // Method to move the enemy towards the player
    void MoveTowardsPlayer()
    {
        // Calculate the direction vector from enemy to player
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize(); // Normalize the direction vector to ensure consistent speed

        // Move the enemy in the direction of the player
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle collision with the player (e.g., deal damage, trigger event, etc.)
        }
    }
}
