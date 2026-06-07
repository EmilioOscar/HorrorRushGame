using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public float delayBeforeLoad = 1.0f; // Set the delay duration in seconds

    public void StartGame()
    {
        StartCoroutine(DelayedLoadScene());
    }

    private IEnumerator DelayedLoadScene()
    {
        yield return new WaitForSeconds(delayBeforeLoad);

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
