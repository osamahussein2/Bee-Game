using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Make full screen mode false because this is to test the resolution matching with NES' screen resolution
    public static bool fullScreenMode = false;

    // Initialize the screen width and height to be equal to NES' screen resolution
    public static int screenWidth = 256;
    public static int screenHeight = 240;

    // Start is called before the first frame update
    void Start()
    {
        // Set the resolution to the screen width and screen height
        Screen.SetResolution(screenWidth, screenHeight, fullScreenMode);
    }

    public void PressPlayButton()
    {
        // Go play the first level
        SceneManager.LoadScene("Level 1");
    }

    public void PressHowToPlayButton()
    {
        // Tell the player how to play
        SceneManager.LoadScene("How to Play");
    }

    public void PressOptionsButton()
    {
        // Transition to the options menu
        SceneManager.LoadScene("Options Menu");
    }

    public void PressCreditsButton()
    {
        // Give credit to our team here
        SceneManager.LoadScene("Credits Menu");
    }
}
