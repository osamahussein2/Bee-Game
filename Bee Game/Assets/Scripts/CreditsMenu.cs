using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    // Create a public reference for the curtain images
    public RawImage leftCurtainImage;
    public RawImage rightCurtainImage;

    // Create 2 Vector3s to animate the curtain movement
    Vector3 moveLeft, moveRight;

    // Create a public reference to the credits title text
    public Text creditsTitleText;

    // Create a public reference to the credits list and names texts
    public Text programmerText, artDesignText, soundComposerText, producerText;
    public Text programmerNamesText, artDesignNameText, soundComposerNameText, producerNamesText;

    // Create a public reference to the credits font that will be used
    public Font creditsFont;

    // Create a public reference to the back text that will be used inside the inspector
    public Text backText;

    // Create a public reference to make the back button active or not active when the credits are rolling
    public GameObject activeBackText;

    void Start()
    {
        // Set the resolution to the screen width and screen height
        Screen.SetResolution(MainMenu.screenWidth, MainMenu.screenHeight, MainMenu.fullScreenMode);

        // Because the curtains are opening and the player needs to wait until the back text is visible
        activeBackText.SetActive(false);
    }

    void Update()
    {
        creditsTitleText.text = "Bee Factory Credits"; // Set up the credits title
        creditsTitleText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        creditsTitleText.fontSize = 10; // Make this smaller to fit the NES resolution but bigger than the other texts

        // Make the text yellow
        creditsTitleText.color = new Color(0.93333333333f, 0.86666666666f, 0.53333333333f, 0.93f);
        creditsTitleText.alignment = TextAnchor.MiddleCenter; // Align it at the middle center of the text box

        // Tell the player to press START to press the back button
        backText.text = "Press START to back to the main menu";

        backText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        backText.fontSize = 7; // Make the text smaller to fit the NES resolution
        backText.color = Color.white; // Make the text white
        backText.alignment = TextAnchor.MiddleCenter; // Align it at the middle center of the text box

        // If the player presses the ENTER key (acts as a START button for NES controller) and the text has activated
        if (activeBackText.activeInHierarchy && Input.GetKeyDown(KeyCode.Return))
        {
            // Go back to the main menu only if the curtains have opened where the back button text is fully visible
            SceneManager.LoadScene("Main Menu");
        }

        // Set up the programmer text
        programmerText.text = "Programmer";

        programmerText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        programmerText.fontSize = 9; // Make the text smaller to fit the NES resolution
        programmerText.color = new Color(0.26666666666f, 0.53333333333f, 1.0f, 1.0f); // Make the text blue
        programmerText.alignment = TextAnchor.UpperRight; // Align it in the upper right of the text box

        // Set up the programmer names to give credit to our programming team making this game
        programmerNamesText.text = "Osama Hussein\ntheRoyalJelly";

        programmerNamesText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        programmerNamesText.fontSize = 9; // Make the text smaller to fit the NES resolution
        programmerNamesText.color = new Color(0.26666666666f, 0.53333333333f, 1.0f, 1.0f); // Make the text blue
        programmerNamesText.alignment = TextAnchor.UpperLeft; // Align it in the upper left of the text box

        // Set up the art design text
        artDesignText.text = "Art design";

        artDesignText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        artDesignText.fontSize = 9; // Make the text smaller to fit the NES resolution
        artDesignText.color = new Color(0.13333333333f, 0.73333333333f, 0.8f, 0.8f); // Make the text cyan
        artDesignText.alignment = TextAnchor.UpperRight; // Align it in the upper right of the text box

        // Set up the art design name to give credit to our artist in making this game
        artDesignNameText.text = "DirectingZeus";

        artDesignNameText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        artDesignNameText.fontSize = 9; // Make the text smaller to fit the NES resolution
        artDesignNameText.color = new Color(0.13333333333f, 0.73333333333f, 0.8f, 0.8f); // Make the text cyan
        artDesignNameText.alignment = TextAnchor.UpperLeft; // Align it in the upper left of the text box

        // Set up the sound composer text
        soundComposerText.text = "Sound composer";

        soundComposerText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        soundComposerText.fontSize = 9; // Make the text smaller to fit the NES resolution

        // Make the text green
        soundComposerText.color = new Color(0.13333333333f, 0.73333333333f, 0.13333333333f, 0.73f);
        soundComposerText.alignment = TextAnchor.UpperRight; // Align it in the upper right of the text box

        // Set up the sound composer name to give credit to our sound composer in making this game
        soundComposerNameText.text = "Preston";

        soundComposerNameText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        soundComposerNameText.fontSize = 9; // Make the text smaller to fit the NES resolution

        // Make the text green
        soundComposerNameText.color = new Color(0.13333333333f, 0.73333333333f, 0.13333333333f, 0.73f);
        soundComposerNameText.alignment = TextAnchor.UpperLeft; // Align it in the upper left of the text box

        // Set up the producer text
        producerText.text = "Producer";

        producerText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        producerText.fontSize = 9; // Make the text smaller to fit the NES resolution

        // Make the text green-cyan
        producerText.color = new Color(0.13333333333f, 0.73333333333f, 0.46666666666f, 0.73f);
        producerText.alignment = TextAnchor.UpperRight; // Align it in the upper right of the text box

        // Set up the producer name to give credit to our producers in making this game
        producerNamesText.text = "Preston\nDirectingZeus";

        producerNamesText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        producerNamesText.fontSize = 9; // Make the text smaller to fit the NES resolution

        // Make the text green-cyan
        producerNamesText.color = new Color(0.13333333333f, 0.73333333333f, 0.46666666666f, 0.73f);
        producerNamesText.alignment = TextAnchor.UpperLeft; // Align it in the upper left of the text box

        // This will be used to animate the left curtain to move left at randomized speed
        moveLeft = new Vector3(Random.Range(-0.2f, -0.15f), 0.0f, 0.0f);

        // This will be used to animate the right curtain to move right at randomized speed
        moveRight = new Vector3(Random.Range(0.15f, 0.2f), 0.0f, 0.0f);

        // Animate both the left and right curtains to open
        leftCurtainImage.gameObject.transform.position += moveLeft;
        rightCurtainImage.gameObject.transform.position += moveRight;

        // Wait for the curtains to move before the back button text will be visible to the player
        if (leftCurtainImage.transform.position.x <= 0.0f && leftCurtainImage.transform.position.x >= -140.0f &&
            rightCurtainImage.transform.position.x >= 0.0f && rightCurtainImage.transform.position.x <= 140.0f)
        {
            activeBackText.SetActive(false);
        }

        // Make the back button text available for the player to press after the curtain is halfway opened
        else if (leftCurtainImage.transform.position.x < -140.0f && rightCurtainImage.transform.position.x > 140.0f)
        {
            activeBackText.SetActive(true);
        }

        // If the left curtain is fully opened, disable it and stop moving to place it there
        if (leftCurtainImage.transform.position.x <= -150.0f)
        {
            leftCurtainImage.transform.position = new Vector2(-150.0f, 0.0f);
            leftCurtainImage.enabled = false;
        }

        // If the right curtain is fully opened, disable it and stop moving to place it there
        if (rightCurtainImage.transform.position.x >= 406.0f)
        {
            rightCurtainImage.transform.position = new Vector2(406.0f, 0.0f);
            rightCurtainImage.enabled = false;
        }
    }
}
