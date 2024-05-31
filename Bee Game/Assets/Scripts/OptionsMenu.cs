using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Make full screen mode false because this is to test the resolution matching with NES' screen resolution
    bool fullScreenMode = false;

    // Initialize the screen width and height to be equal to NES' screen resolution
    int screenWidth = 256;
    int screenHeight = 240;

    // Create a public reference to any sfx and music audio files we have inside the game for the player to modify its volume
    public AudioSource[] sfxSource;
    public AudioSource[] musicSource;

    int sfxIndex; // This will randomize a certain SFX to play
    int musicIndex; // This will randomize a certain music to play

    float timerValue; // This is used for determining the time of the SFX index updating
    float timerTarget = 1.0f; // This is used to reset the timer value back to 0 to keep updating the SFX index

    // Create 2 images of SFX and no SFX images to use when the player presses the SFX button
    public Image sfxImage;
    public Image noSFXimage;

    // Create 2 images of music and no music images to use when the player presses the music button
    public Image musicImage;
    public Image noMusicImage;

    // Start is called before the first frame update
    void Start()
    {
        // Set the resolution to the screen width and screen height
        Screen.SetResolution(screenWidth, screenHeight, fullScreenMode);

        noSFXimage.gameObject.SetActive(false); // Turn off the no SFX image by default
        sfxImage.gameObject.SetActive(true); // Turn on SFX at start

        noMusicImage.gameObject.SetActive(false); // Turn off the no music image by default
        musicImage.gameObject.SetActive(true); // Turn on music at start
    }

    // Update is called once per frame
    void Update()
    {
        // Set the SFX and music indexes to randomize between its first index and 1 more than the length of the array
        sfxIndex = Random.Range(0, sfxSource.Length + 1);
        musicIndex = Random.Range(0, musicSource.Length + 1);

        // Increase the timer value over time
        timerValue += Time.deltaTime;
    }

    public void PressBackButton()
    {
        // Go back to the main menu
        SceneManager.LoadScene("Main Menu");
    }

    public void TurnOnSFX()
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
    }

    public void TurnOffSFX()
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
    }

    public void TurnOnMusic()
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
        }
    }

    public void TurnOffMusic()
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
        }
    }
}
