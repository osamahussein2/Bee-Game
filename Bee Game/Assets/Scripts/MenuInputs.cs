using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInputs : MonoBehaviour
{
    public RawImage pauseTexture;
    public Text pauseMenuText;
    public Font inGameFont;

    public RawImage pauseAndResumeInstruction;
    public Text resumeText;
    public Text quitToMainMenuText;

    public static bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        PauseGame();

        pauseTexture.gameObject.SetActive(false);
        pauseAndResumeInstruction.gameObject.SetActive(false);

        // If the default bee music is found and the default bee music is still playing
        if (OptionsMenu.defaultBeeMusic != null && OptionsMenu.defaultBeeMusic.isPlaying)
        {
            OptionsMenu.defaultBeeMusic.Stop(); // Stop playing the default bee music
            OptionsMenu.defaultBeeMusic.volume = 0; // Set the volume to 0, just in case
        }

        // Set the resolution to the screen width and screen height
        Screen.SetResolution(MainMenu.screenWidth, MainMenu.screenHeight, MainMenu.fullScreenMode);

        // Find the factory music audio source game object
        OptionsMenu.factoryLevelMusic = GameObject.Find("Factory Music").GetComponent<AudioSource>();

        // If the factory music is found but not playing and the player turned on music in the options menu
        if (OptionsMenu.factoryLevelMusic != null && !OptionsMenu.factoryLevelMusic.isPlaying &&
            PlayerPrefs.GetString(OptionsMenu.musicImageString) == OptionsMenu.musicOn)
        {
            OptionsMenu.factoryLevelMusic.Play(); // Play the factory music
        }

        // If the factory music is playing, set the volume to 1 and enable loop
        if (OptionsMenu.factoryLevelMusic.isPlaying)
        {
            OptionsMenu.factoryLevelMusic.volume = 1;
            OptionsMenu.factoryLevelMusic.loop = true;
        }

        // If the factory music is found but the player turned off music in the options menu
        if (OptionsMenu.factoryLevelMusic != null &&
            PlayerPrefs.GetString(OptionsMenu.musicImageString) == OptionsMenu.musicOff)
        {
            OptionsMenu.factoryLevelMusic.Stop(); // Stop playing the factory music
            OptionsMenu.factoryLevelMusic.volume = 0; // Set the volume to 0
        }
    }

    // Update is called once per frame
    void Update()
    {
        pauseMenuText.text = "PAUSED!";
        pauseMenuText.font = inGameFont;
        pauseMenuText.fontSize = 10;
        pauseMenuText.alignment = TextAnchor.MiddleCenter;

        resumeText.text = "Press START to resume game!";
        resumeText.font = inGameFont;
        resumeText.fontSize = 7;
        resumeText.alignment = TextAnchor.MiddleCenter;

        quitToMainMenuText.text = "Press SELECT to quit to main menu!";
        quitToMainMenuText.font = inGameFont;
        quitToMainMenuText.fontSize = 7;
        quitToMainMenuText.alignment = TextAnchor.MiddleCenter;

        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the application
            Application.Quit(); //End game on key press for testing.
        }

        if (Input.GetKeyDown(KeyCode.Return) && !pauseTexture.gameObject.activeInHierarchy)
        {
            pauseTexture.gameObject.SetActive(true);
            pauseAndResumeInstruction.gameObject.SetActive(true);

            gamePaused = true;
            PauseGame();
        }

        else if (Input.GetKeyDown(KeyCode.Return) && pauseTexture.gameObject.activeInHierarchy)
        {
            pauseTexture.gameObject.SetActive(false);
            pauseAndResumeInstruction.gameObject.SetActive(false);

            gamePaused = false;
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && pauseTexture.gameObject.activeInHierarchy)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void PauseGame()
    {
        if (gamePaused)
        {
            Time.timeScale = 0;
        }

        else if (!gamePaused)
        {
            Time.timeScale = 1;
        }
    }

}
