using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Make full screen mode false because this is to test the resolution matching with NES' screen resolution
    public static bool fullScreenMode = false;

    // Initialize the screen width and height to be equal to NES' screen resolution
    public static int screenWidth = 256;
    public static int screenHeight = 240;

    // Create 4 public references of Texts to use in the inspector
    public Text playText;
    public Text howToPlayText;
    public Text optionsText;
    public Text creditsText;

    public Font mainMenuFont; // Create a public reference for the font to use in the inspector

    // Start is called before the first frame update
    void Start()
    {
        // Set the resolution to the screen width and screen height
        Screen.SetResolution(screenWidth, screenHeight, fullScreenMode);
    }

    void Update()
    {
        // Return is the enter key on PC and acts as the START button for Nintendo Entertainment System controller
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Go play the first level
            SceneManager.LoadScene("Level 1");
        }

        // Acts as the SELECT button for Nintendo Entertainment System controller
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Tell the player how to play
            SceneManager.LoadScene("How to Play");
        }

        // Acts as the A button for Nintendo Entertainment System controller
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Transition to the options menu
            SceneManager.LoadScene("Options Menu");
        }

        // Acts as the B button for Nintendo Entertainment System controller
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Give credit to our team here
            SceneManager.LoadScene("Credits Menu");
        }

        playText.text = "Press START to play";
        playText.font = mainMenuFont;
        playText.fontSize = 7;
        playText.color = Color.white;
        playText.alignment = TextAnchor.MiddleCenter;

        howToPlayText.text = "Press SELECT to open the how to play screen";
        howToPlayText.font = mainMenuFont;
        howToPlayText.fontSize = 7;
        howToPlayText.color = Color.white;
        howToPlayText.alignment = TextAnchor.MiddleCenter;

        optionsText.text = "Press A to open the options screen";
        optionsText.font = mainMenuFont;
        optionsText.fontSize = 7;
        optionsText.color = Color.white;
        optionsText.alignment = TextAnchor.MiddleCenter;

        creditsText.text = "Press B to open the credits screen";
        creditsText.font = mainMenuFont;
        creditsText.fontSize = 7;
        creditsText.color = Color.white;
        creditsText.alignment = TextAnchor.MiddleCenter;
    }
}
