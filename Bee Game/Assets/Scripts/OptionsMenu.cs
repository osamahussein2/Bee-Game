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

    // Create a public reference for sfx and music sliders for the player to play around with
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;

    // Create a public reference to any sfx and music audio files we have inside the game for the player to modify its volume
    public AudioSource[] sfxSource;
    public AudioSource musicSource;

    // Create a public reference to the sfx and music volume values text to display it to the player as they modify the slider
    public TextMeshProUGUI sfxVolumeValue;
    public TextMeshProUGUI musicVolumeValue;

    // Create a float that converts the max slider value of 1 to a percent of 100
    float percentage = 100.0f;

    int sfxIndex; // This will randomize a certain SFX to play

    float timerValue; // This is used for determining the time of the SFX index updating
    float timerTarget = 0.5f; // This is used to reset the timer value back to 0 to keep updating the SFX index

    // Start is called before the first frame update
    void Start()
    {
        // Set the resolution to the screen width and screen height
        Screen.SetResolution(screenWidth, screenHeight, fullScreenMode);

        // Initialize the sfx and music slider values equal to their max values
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFX volume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("Music volume");
    }

    // Update is called once per frame
    void Update()
    {
        sfxIndex = Random.Range(0, 2);

        timerValue += Time.deltaTime;

        // Create local variables taking in the sfx volume percentage and music volume percentage
        float sfxVolumePercentage = Mathf.Round(sfxVolumeSlider.value * percentage);
        float musicVolumePercentage = Mathf.Round(musicVolumeSlider.value * percentage);

        // Write a text of the sfx volume and music volume percentages inside the options menu
        sfxVolumeValue.text = sfxVolumePercentage.ToString() + "%";
        musicVolumeValue.text = musicVolumePercentage.ToString() + "%";

        // If the sfx slider volume is at 0, make the sfx audio volume to 0 as well
        if (sfxVolumeSlider.value <= 0)
        {
            for (int i = 0; i < sfxSource.Length; i++)
            {
                sfxSource[i].volume = 0;
            }
        }

        // If the music slider volume is at 0, make the music audio volume to 0 as well
        if (musicVolumeSlider.value <= 0)
        {
            musicSource.volume = 0;
        }
    }

    public void PressBackButton()
    {
        // Go back to the main menu
        SceneManager.LoadScene("Main Menu");
    }

    public void ModifySFXVolume()
    {
        // Change the sfx volume using the slider
        for (int i = 0; i < sfxSource.Length; i++)
        {
            PlayerPrefs.SetFloat("SFX volume", sfxSource[i].volume = sfxVolumeSlider.value);
        }

        // If the timer value is greater than the target time, use the sfx index to randomize playing between the SFXs
        if (timerValue > timerTarget)
        {
            if (sfxIndex == 0)
            {
                sfxSource[0].Play();

                timerValue = 0; // Reset this to 0 to keep updating the sfx index
            }

            if (sfxIndex == 1)
            {
                sfxSource[1].Play();

                timerValue = 0; // Reset this to 0 to keep updating the sfx index
            }
        }
    }

    public void ModifyMusicVolume()
    {
        // Change the music volume using the slider
        PlayerPrefs.SetFloat("Music volume", musicSource.volume = musicVolumeSlider.value);

        // Stop the SFX audio from playing when the player modifies the music slider
        for (int i = 0; i < sfxSource.Length; i++)
        {
            sfxSource[i].Stop();
        }
    }
}
