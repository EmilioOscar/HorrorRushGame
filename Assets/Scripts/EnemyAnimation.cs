using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private EnemyAI enemyAI;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyAI = GetComponent<EnemyAI>();

        if (enemyAI == null)
        {
            Debug.LogError("EnemyAI component not found!");
        }
    }

    private void Update()
    {
        if (enemyAI != null)
        {
            // No need to check for IsAppearing or IsDisappearing
            // Do any other animation-related logic here
        }
    }
}
