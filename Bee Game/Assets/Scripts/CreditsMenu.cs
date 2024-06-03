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

    // Create a public reference to the credits list and names texts
    public Text creditsListText;
    public Text creditsNameText;

    // Create a public reference to the credits font that will be used
    public Font creditsFont;

    // Create a public reference to make the back button active or not active when the credits are rolling
    public GameObject backButton;

    void Start()
    {
        // Set the resolution to the screen width and screen height
        Screen.SetResolution(MainMenu.screenWidth, MainMenu.screenHeight, MainMenu.fullScreenMode);

        moveLeft = new Vector3(-0.01f, 0.0f, 0.0f); // This will be used to animate the left curtain to move left
        moveRight = new Vector3(0.01f, 0.0f, 0.0f); // This will be used to animate the right curtain to move right

        // Because the curtains are opening and the player needs to wait until the back button is visible
        backButton.SetActive(false);
    }

    void Update()
    {
        // Set up the credits list to give credit to our team doing specific roles in making this game
        creditsListText.text = "Programmer\r\n\r\n\r\nArt design\r\n\r\n" +
            "Sound composer\r\n\r\nProducer";

        creditsListText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        creditsListText.fontSize = 10; // Make the text smaller to fit the NES resolution
        creditsListText.alignment = TextAnchor.UpperRight; // Align it in the upper right of the text box

        // Set up the credits name to give credit to our team members making this game
        creditsNameText.text = "Osama Hussein\r\ntheRoyalJelly\r\n\r\nDirectingZeus\r\n\r\n" +
            "Preston\r\n\r\n\nPreston\r\nDirectingZeus";

        creditsNameText.font = creditsFont; // Set this text to use the Nintendo font in the inspector
        creditsNameText.fontSize = 10; // Make the text smaller to fit the NES resolution
        creditsNameText.alignment = TextAnchor.UpperLeft; // Align it in the upper left of the text box

        // Animate both the left and right curtains to open
        leftCurtainImage.gameObject.transform.position += moveLeft;
        rightCurtainImage.gameObject.transform.position += moveRight;

        // Wait for the curtains to move before the back button will be visible for the player to press
        if (leftCurtainImage.transform.position.x <= 0.0f && leftCurtainImage.transform.position.x >= -50.0f &&
            rightCurtainImage.transform.position.x >= 0.0f && rightCurtainImage.transform.position.x <= 50.0f)
        {
            backButton.SetActive(false);
        }

        // Make the back button available for the player to press after the curtain is halfway opened
        else if (leftCurtainImage.transform.position.x < -60.0f && rightCurtainImage.transform.position.x > 60.0f)
        {
            backButton.SetActive(true);
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

    public void PressBackButton()
    {
        // Go back to the main menu only if the curtains have opened where the back button is fully visible
        SceneManager.LoadScene("Main Menu");
    }
}
