using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuOptions : MonoBehaviour
{
    public GameObject optionsElements;
    public GameObject mainMenuElements;
    public Slider musicSlider;
    public Slider SFXSlider;
    public float musicValue;
    public float SFXValue;
    public AudioMixer mixer;

    private void Start()
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicSlider")) * 20);
        mixer.SetFloat("EffectsVol", Mathf.Log10(PlayerPrefs.GetFloat("EffectsSlider")) * 20);
    }

    public void OptionsOpen()
    {
        mainMenuElements.SetActive(false);
        optionsElements.SetActive(true);
        musicSlider.value=PlayerPrefs.GetFloat("MusicSlider");
        SFXSlider.value = PlayerPrefs.GetFloat("EffectsSlider");
    }

    public void MusicVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        musicValue = Mathf.Log10(sliderValue) * 20;
    }

    public void EffectsVolume(float sliderValue)
    {
        mixer.SetFloat("EffectsVol", Mathf.Log10(sliderValue) * 20);
        SFXValue = Mathf.Log10(sliderValue) * 20;
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("MusicSlider", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicValue);

        PlayerPrefs.SetFloat("EffectsSlider", SFXSlider.value);
        PlayerPrefs.SetFloat("EffectsVol", SFXValue);

        mainMenuElements.SetActive(true);
        optionsElements.SetActive(false);
    }
}