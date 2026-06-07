using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    private bool isInvincible = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isInvincible && (collision.gameObject.CompareTag("Traps") || collision.gameObject.CompareTag("Enemy")))
        {
            Die();
        }
    }

    private void Die()
    {
        AudioManager.Instance.PlaySFX("deathSoundEffect");
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        // Set invincibility period (e.g., 2 seconds)
        StartCoroutine(InvincibilityPeriod(2f));

        // Reset the enemy state when the player respawns
        ResetEnemyState();

        // You can add more logic for handling the player's death here, such as disabling control, playing death sound, or any other necessary actions.

        // Use coroutine to restart the level after a delay
        StartCoroutine(RestartLevelAfterDelay(2f));
    }

    private void ResetEnemyState()
    {
        // Find the EnemyAI component and reset its state
        EnemyAI[] enemyAIs = FindObjectsOfType<EnemyAI>();
        foreach (EnemyAI enemyAI in enemyAIs)
        {
            if (enemyAI != null)
            {
                Debug.Log("Resetting enemy state");
                enemyAI.ResetEnemyState();
            }
        }
    }

    private IEnumerator RestartLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator InvincibilityPeriod(float duration)
    {
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }
}
