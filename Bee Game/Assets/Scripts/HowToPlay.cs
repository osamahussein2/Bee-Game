using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public Text backText; // Create a back button text to use inside the inspector
    public Font howToPlayFont; // Create a font to use inside the inspector

    public Text dPadHelpText;
    public Text startButtonHelpText;
    public Text selectButtonHelpText;
    public Text aButtonHelpText;
    public Text bButtonHelpText;

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

        dPadHelpText.text = "Move the pointer around"; // Tell the player what the D-Pad buttons do
        dPadHelpText.font = howToPlayFont; // Set this text to use the Nintendo font in the inspector
        dPadHelpText.fontSize = 6; // Make the text smaller to fit the NES resolution
        dPadHelpText.color = Color.white; // Make the text white
        dPadHelpText.alignment = TextAnchor.MiddleLeft;// Align it at the middle left of the text box

        startButtonHelpText.text = "Play the game (main menu only)"; // Tell the player what the START button does
        startButtonHelpText.font = howToPlayFont; // Set this text to use the Nintendo font in the inspector
        startButtonHelpText.fontSize = 6; // Make the text smaller to fit the NES resolution
        startButtonHelpText.color = Color.white; // Make the text white
        startButtonHelpText.alignment = TextAnchor.MiddleLeft;// Align it at the middle left of the text box

        selectButtonHelpText.text = "Open the building menu"; // Tell the player what the SELECT button does
        selectButtonHelpText.font = howToPlayFont; // Set this text to use the Nintendo font in the inspector
        selectButtonHelpText.fontSize = 6; // Make the text smaller to fit the NES resolution
        selectButtonHelpText.color = Color.white; // Make the text white
        selectButtonHelpText.alignment = TextAnchor.MiddleLeft;// Align it at the middle left of the text box

        aButtonHelpText.text = "Collect resource"; // Tell the player what the A button does
        aButtonHelpText.font = howToPlayFont; // Set this text to use the Nintendo font in the inspector
        aButtonHelpText.fontSize = 6; // Make the text smaller to fit the NES resolution
        aButtonHelpText.color = Color.white; // Make the text white
        aButtonHelpText.alignment = TextAnchor.MiddleLeft;// Align it at the middle left of the text box

        bButtonHelpText.text = "Place building/factory"; // Tell the player what the B button does
        bButtonHelpText.font = howToPlayFont; // Set this text to use the Nintendo font in the inspector
        bButtonHelpText.fontSize = 6; // Make the text smaller to fit the NES resolution
        bButtonHelpText.color = Color.white; // Make the text white
        bButtonHelpText.alignment = TextAnchor.MiddleLeft;// Align it at the middle left of the text box
    }
}
