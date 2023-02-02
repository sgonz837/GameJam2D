using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the Inspector
    public float moveSpeed = 2f; // The enemy's movement speed
    public float viewDistance = 5f; // The distance the enemy can see the player
    public float viewAngle = 90f; // The angle the enemy can see the player (in degrees)
    public LayerMask groundLayer; // Assign the ground layer in the Inspector
    private Vector2 previousPosition; // The enemy's position in the previous frame
    public Animator animator;

    private void Update()
    {
        // Find the direction to the player
        Vector2 directionToPlayer = player.position - transform.position;

        // Check if the player is within the enemy's view distance and angle
        if (directionToPlayer.magnitude < viewDistance && Vector2.Angle(directionToPlayer, transform.right) < viewAngle / 2)
        {
            // Save the enemy's previous position
            previousPosition = transform.position;

            // Move towards the player
            Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), moveSpeed * Time.deltaTime);

            animator.SetBool("Move", true);

            // Check if the new position collides with the ground layer
            if (!Physics2D.OverlapCircle(newPosition, 0.1f, groundLayer))
            {
                transform.position = newPosition;
            }
            else
            {
                // If so, restore the enemy's previous position
                transform.position = previousPosition;
            }
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }
}
