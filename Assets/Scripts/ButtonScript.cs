using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private Button button;
    public AudioSource MainButtonSound; // Drag your AudioSource reference into the Unity Editor
    public Options optionsScript; // Drag the GameObject with the Options script attached in the Unity Editor
    public Startscreen startscreenScript; // Declare the Startscreen variable

    private void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(PlayButtonClick);
        }
    }

    private void PlayButtonClick()
    {
        Debug.Log(gameObject.name + " Button Clicked"); // Log the name of the button clicked

        if (MainButtonSound != null)
        {
            MainButtonSound.Play();
            Debug.Log("Sound Played");
        }

        // Add any other functionality you want to perform when a button is clicked
        if (gameObject.name == "PlayButton")
        {
            // Put the code for starting the game or loading a scene for the play button
        }
        else if (gameObject.name == "QuitButton")
        {
            // Put the code for quitting the game or any other action for the quit button
            Application.Quit(); // Note: Application.Quit may not work in the Unity Editor.
        }
        else if (gameObject.name == "OptionsButton")
        {
            if (MainButtonSound != null)
            {
                MainButtonSound.Play();
                Debug.Log("OptionsButton Sound Played");
            }
            else
            {
                Debug.LogError("MainButtonSound is null!");
            }

            // Call the LoadOptionsScene method from the Options script
            optionsScript.LoadOptionsScene();
        }
        else if (gameObject.name == "BackButton")
        {
            // Put the code for loading the "Startscreen" scene
            if (startscreenScript != null)
            {
                startscreenScript.LoadStartscreenScene();
            }
            else
            {
                Debug.LogError("StartscreenScript is null!");
            }
        }
    }
}
