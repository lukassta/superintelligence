using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        LoadVolume();
    }

    private void LoadVolume()
    {
        if(PlayerPrefs.HasKey("musicVolume")) musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        if(PlayerPrefs.HasKey("SFXVolume")) sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        
        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetMusicVolume()
    {
       float volume = musicSlider.value;
       myMixer.SetFloat("MusicVolume", Mathf.Log10(volume)*20);
       PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFXVolume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}
