using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMark3 : MonoBehaviour
{

    public AudioMixer audioMixer; //Adds audio mixer to script.

    Resolution[] resOptions; //Allows me to set a resolution so the game can be a small resolution or fullscreen.


    // Start is called before the first frame update
    void Start()
    {
        resOptions = Screen.resolutions;

        // Switch to 640 x 480 full-screen
        Screen.SetResolution(640, 480, true);
        
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); //Sets volume of audio.
    }

    public void SetFullscreen(bool isFullscreen)
    {
            Screen.fullScreen = isFullscreen; //Sets the screen to full screen.
    }

}
