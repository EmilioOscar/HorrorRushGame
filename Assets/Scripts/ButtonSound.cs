using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button continueButton; // Reference to  continue button
    public AudioClip buttonClickSound; // The sound to play

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        continueButton.onClick.AddListener(PlayButtonSound);
    }

    public void PlayButtonSound()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
