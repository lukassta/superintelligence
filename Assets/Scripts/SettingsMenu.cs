using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer myMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public TMP_Dropdown resolutionDroprown;

    Resolution[] resolutions;

    private void Start()
    {
        LoadVolume();

        resolutions = Screen.resolutions;

        resolutionDroprown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x "+ resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
               {
                    currentResolutionIndex = i;
               }
        }

        resolutionDroprown.AddOptions(options);
        resolutionDroprown.value = currentResolutionIndex;
        resolutionDroprown.RefreshShownValue();
    }

    private void LoadVolume()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            float music_volume = PlayerPrefs.GetFloat("musicVolume");
            musicSlider.value = music_volume;
            SetMusicVolume(music_volume);
        } 
        if(PlayerPrefs.HasKey("SFXVolume"))
        {
            float SFX_volume = PlayerPrefs.GetFloat("SFXVolume");;
            sfxSlider.value = SFX_volume;
            SetSFXVolume(SFX_volume);
        } 
    }

    public void SetMusicVolume(float volume)
    {
       myMixer.SetFloat("MusicVolume", Mathf.Log10(volume)*20);
       PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        myMixer.SetFloat("SFXVolume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
