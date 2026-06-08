using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayButton : MonoBehaviour
{
    private Button button;
    public AudioSource MainButtonSound; // Drag AudioSource reference into the Unity Editor

    private void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(PlayButtonClick);
        }
    }

    private IEnumerator DelayedSoundPlay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (MainButtonSound != null)
        {
            MainButtonSound.Play();
            Debug.Log("Sound Played");
        }
    }

    private void PlayButtonClick()
    {
        Debug.Log("Play Button Clicked");

        float delay = 2.0f; // Adjust this value to set the desired delay in seconds
        StartCoroutine(DelayedSoundPlay(delay));

        // Add any other functionality you want to perform when the play button is clicked
    }
}
