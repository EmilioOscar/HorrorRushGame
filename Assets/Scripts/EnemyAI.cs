using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public float detectionRange = 5f;

    private PlayerMovement player;
    private SpriteRenderer sprite;

    private bool isPlayerDead = false;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        sprite = GetComponent<SpriteRenderer>();

        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
    }

    void Update()
    {
        if (player != null && !isPlayerDead)
        {
            float distance = Vector2.Distance(transform.position, player.PlayerPosition);

            if (distance < detectionRange)
            {
                MoveTowardsPlayer();
            }
            else
            {
                // Handle other logic when the player is not detected
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = ((Vector2)player.PlayerPosition - (Vector2)transform.position).normalized;

        // Update the enemy's position directly
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Flip the sprite based on the direction
        if (direction.x > 0f)
        {
            // Moving right
            sprite.flipX = false;
        }
        else if (direction.x < 0f)
        {
            // Moving left
            sprite.flipX = true;
        }
    }

    // Method to reset the enemy state when the player respawns
    public void ResetEnemyState()
    {
        isPlayerDead = false;
        // Add any other state resetting logic here if needed
    }

    // Method to set the player's death state
    public void SetPlayerDeadState(bool isDead)
    {
        isPlayerDead = isDead;
    }
}
