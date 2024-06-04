using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public Text backText; // Create a back button text to use inside the inspector
    public Font howToPlayFont; // Create a font to use inside the inspector

    // Start is called before the first frame update
    void Start()
    {
        // Set the resolution to the screen width and screen height
        Screen.SetResolution(MainMenu.screenWidth, MainMenu.screenHeight, MainMenu.fullScreenMode);
    }

    void Update()
    {
        // Tell the player to press START to press the back button
        backText.text = "Press START to back to the main menu";

        backText.font = howToPlayFont; // Set this text to use the Nintendo font in the inspector
        backText.fontSize = 7; // Make the text smaller to fit the NES resolution
        backText.color = Color.white; // Make the text white
        backText.alignment = TextAnchor.MiddleCenter; // Align it at the middle center of the text box

        // If the player presses the ENTER key (acts as a START button for NES controller)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Go back to the main menu only if the curtains have opened where the back button text is fully visible
            SceneManager.LoadScene("Main Menu");
        }
    }
}
