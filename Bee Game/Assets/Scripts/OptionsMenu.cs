using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Create a public reference to any sfx and music audio files we have inside the game for the player to modify its volume
    public AudioSource[] sfxSource;
    public AudioSource[] musicSource;

    // Create a static reference of the default bee music to use it outside of this script
    public static AudioSource defaultBeeMusic;

    int sfxIndex; // This will randomize a certain SFX to play
    int musicIndex; // This will randomize a certain music to play

    float timerValue; // This is used for determining the time of the SFX and music indexes updating
    float timerTarget = 0.1f; // This is used to reset the timer value back to 0 to keep updating the SFX and music indexes

    // Create 2 images of SFX and no SFX images to use when the player presses the SFX button
    public RawImage sfxImage;
    public RawImage noSFXimage;

    // Create 2 images of music and no music images to use when the player presses the music button
    public RawImage musicImage;
    public RawImage noMusicImage;

    // Create a back button text object and use it inside the inspector
    public Text backText;

    // Create a public font to use inside the inspector
    public Font optionsFont;

    // Create a public static music image string to use it inside the Main Menu script
    public static string musicImageString = "MusicImage";

    // Create a public static music on and music off strings to use it inside the Main Menu script
    public static string musicOn = "Music On";
    public static string musicOff = "Music Off";

    // Start is called before the first frame update
    void Start()
    {
        // Set the resolution to the screen width and screen height
        Screen.SetResolution(MainMenu.screenWidth, MainMenu.screenHeight, MainMenu.fullScreenMode);

        // Save the SFX image at start if the player chooses to turn SFX on
        if (PlayerPrefs.GetString("sfxImage") == "SFX On")
        {
            sfxImage.gameObject.SetActive(true); // Turn on SFX using the SFX image
            noSFXimage.gameObject.SetActive(false); // Disable the no SFX image
        }

        // Save the no SFX image at start if the player chooses to turn SFX off
        if (PlayerPrefs.GetString("sfxImage") == "SFX Off")
        {
            noSFXimage.gameObject.SetActive(true); // Turn off SFX using the no SFX image
            sfxImage.gameObject.SetActive(false); // Disable the SFX image
        }

        // Save the music image at start if the player chooses to turn music on
        if (PlayerPrefs.GetString(musicImageString) == musicOn)
        {
            musicImage.gameObject.SetActive(true); // Turn on music using the music image
            noMusicImage.gameObject.SetActive(false); // Disable the no music image

            // If the default bee music is not null
            if (defaultBeeMusic != null)
            {
                defaultBeeMusic.volume = 1; // Set the default bee music volume to 1
                defaultBeeMusic.loop = true; // Set the default bee music to continue looping
            }
        }

        // Save the no music image at start if the player chooses to turn music off
        if (PlayerPrefs.GetString(musicImageString) == musicOff)
        {
            noMusicImage.gameObject.SetActive(true); // Turn off music using the no music image
            musicImage.gameObject.SetActive(false); // Disable the music image

            // If the default bee music is not null
            if (defaultBeeMusic != null)
            {
                defaultBeeMusic.Stop(); // Stop playing the default bee music if the player turned off music
                defaultBeeMusic.volume = 0; // Set the default bee music volume to 0
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set the SFX and music indexes to randomize between its first index and 1 more than the length of the array
        sfxIndex = Random.Range(0, sfxSource.Length + 1);
        musicIndex = Random.Range(0, musicSource.Length + 2);

        // Increase the timer value over time
        timerValue += Time.deltaTime;

        // Tell the player to press START to press the back button
        backText.text = "Press START to back to the main menu";

        backText.font = optionsFont; // Set this text to use the Nintendo font in the inspector
        backText.fontSize = 7; // Make the text smaller to fit the NES resolution
        backText.color = Color.white; // Make the text white
        backText.alignment = TextAnchor.MiddleCenter; // Align it at the middle center of the text box

        // If the player pressed the ENTER key (acts as a START button for NES)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Go back to the main menu
            SceneManager.LoadScene("Main Menu");
        }

        // If music image is not visible but no music image is visible and the player pressed Z (acts as a A button for NES)
        if (!musicImage.gameObject.activeInHierarchy && noMusicImage.gameObject.activeInHierarchy &&
            Input.GetKeyDown(KeyCode.Z))
        {
            // Disable the no music image
            noMusicImage.gameObject.SetActive(false);

            // Use the music image to indicate to the player that they turned on music
            musicImage.gameObject.SetActive(true);

            // If the timer is greater than its target, play the music at a specific index and reset the timer again
            if (timerValue > timerTarget)
            {
                if (musicIndex == 0)
                {
                    musicSource[0].volume = 1; // Set this music volume to 1 if it reaches this music index
                    musicSource[0].Play(); // Play this music when the player turns on music

                    timerValue = 0; // Reset this to 0 to keep updating the sfx index
                }

                if (musicIndex == 1)
                {
                    musicSource[1].volume = 1; // Set this music volume to 1 if it reaches this music index
                    musicSource[1].Play(); // Play this music when the player turns on music

                    timerValue = 0; // Reset this to 0 to keep updating the sfx index
                }

                if (musicIndex == 2)
                {
                    musicSource[2].volume = 1; // Set this music volume to 1 if it reaches this music index
                    musicSource[2].Play(); // Play this music when the player turns on music

                    timerValue = 0; // Reset this to 0 to keep updating the sfx index
                }

                if (musicIndex == 3)
                {
                    defaultBeeMusic.volume = 1; // Set this music volume to 1 if it reaches this music index
                    defaultBeeMusic.Play(); // Play this music when the player turns on music

                    timerValue = 0; // Reset this to 0 to keep updating the sfx index
                }
            }

            // Set the string to save the player's option when they want to turn on music
            PlayerPrefs.SetString(musicImageString, musicOn);
        }

        // If no music image is not visible but music image is visible and the player pressed Z (acts as a A button for NES)
        else if (!noMusicImage.gameObject.activeInHierarchy && musicImage.gameObject.activeInHierarchy &&
            Input.GetKeyDown(KeyCode.Z))
        {
            // Use the no music image to indicate that the player turned off music
            noMusicImage.gameObject.SetActive(true);

            // Disable the music image
            musicImage.gameObject.SetActive(false);

            // Loop through all the music sources
            for (int i = 0; i < musicSource.Length; i++)
            {
                musicSource[i].volume = 0; // Set all music volume to 0
                musicSource[i].Stop(); // Stop all SFXs from playing

                defaultBeeMusic.volume = 0; // Set the default bee music volume to 0
                defaultBeeMusic.Stop(); // Stop playing the default bee music if the player turned off music
            }

            // Set the string to save the player's option when they want to turn off music
            PlayerPrefs.SetString(musicImageString, musicOff);
        }

        // If sfx image is not visible but no sfx image is visible and the player pressed X (acts as a B button for NES)
        if (!sfxImage.gameObject.activeInHierarchy && noSFXimage.gameObject.activeInHierarchy &&
            Input.GetKeyDown(KeyCode.X))
        {
            // Disable the no SFX image
            noSFXimage.gameObject.SetActive(false);

            // Use the SFX image to tell the player they turned SFX on
            sfxImage.gameObject.SetActive(true);

            // If the timer is greater than its target, play the SFX at a specific index and reset the timer again
            if (timerValue > timerTarget)
            {
                if (sfxIndex == 0)
                {
                    sfxSource[0].volume = 1; // Set this SFX volume to 1
                    sfxSource[0].Play(); // Play this SFX at this SFX index

                    timerValue = 0; // Reset this to 0 to keep updating the sfx index
                }

                if (sfxIndex == 1)
                {
                    sfxSource[1].volume = 1; // Set this SFX volume to 1
                    sfxSource[1].Play(); // Play this SFX at this SFX index

                    timerValue = 0; // Reset this to 0 to keep updating the sfx index
                }
            }

            // Loop through all the music sources
            for (int i = 0; i < musicSource.Length; i++)
            {
                musicSource[i].volume = 0; // Set all music volume to 0
                musicSource[i].Stop(); // Stop all SFXs from playing
            }

            // Set the string to save the player's option when they want to turn on SFX
            PlayerPrefs.SetString("sfxImage", "SFX On");
        }

        // If no sfx image is not visible but sfx image is visible and the player pressed X (acts as a B button for NES)
        else if (!noSFXimage.gameObject.activeInHierarchy && sfxImage.gameObject.activeInHierarchy &&
            Input.GetKeyDown(KeyCode.X))
        {
            // Use the no SFX image to tell the player they turned SFX off
            noSFXimage.gameObject.SetActive(true);

            // Disable the SFX image
            sfxImage.gameObject.SetActive(false);

            // Loop through all the sfx sources
            for (int i = 0; i < sfxSource.Length; i++)
            {
                sfxSource[1].volume = 0; // Set all SFX volume to 0
                sfxSource[i].Stop(); // Stop all SFXs from playing
            }

            // Loop through all the music sources
            for (int i = 0; i < musicSource.Length; i++)
            {
                musicSource[i].volume = 0; // Set all music volume to 0
                musicSource[i].Stop(); // Stop all SFXs from playing
            }

            // Set the string to save the player's option when they want to turn off SFX
            PlayerPrefs.SetString("sfxImage", "SFX Off");
        }
    }
}
