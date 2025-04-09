using System;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject sound;
    [SerializeField] private Text soundVolumeText;
    [SerializeField] private Slider soundVolumeSlider;
    public float SoundVolume;


    public void SliderChange(float value)
    {
        double localValue = value * 100;
        double ValueForDisplay = Math.Round(localValue);
        if (soundVolumeText.gameObject.activeSelf)
        {
            soundVolumeText.text = ValueForDisplay.ToString();
        }

        SoundVolume = value;
        PlayerPrefs.SetFloat("SoundVolume", SoundVolume);
    }

    void LoadSound()
    {
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            SoundVolume = PlayerPrefs.GetFloat("SoundVolume");
            Debug.Log(SoundVolume + " also found the player pref");
            soundVolumeSlider.value = SoundVolume;
            double soundVolumeAsDouble = SoundVolume * 100;
            soundVolumeText.text = (Math.Round(soundVolumeAsDouble)).ToString();
        }
        else
        {
            SoundVolume = 1.00f;
            soundVolumeSlider.value = SoundVolume;
            soundVolumeText.text = (SoundVolume * 100).ToString();
        }
    }
    
    public void EnableControls()
    {
        controls.SetActive(true);
        menu.SetActive(false);
        options.SetActive(false);
    }

    void DisableControls()
    {
        if (controls.activeInHierarchy)
        {
            controls.SetActive(false);
            menu.SetActive(false);
            options.SetActive(true);
        }
    }

    public void EnableOptions()
    {
        options.SetActive(true);
        menu.SetActive(false);
    }

    public void DisableOptions()
    {
        options.SetActive(false);
        menu.SetActive(true);
    }

    public void EnableSound()
    {
        options.SetActive(false);
        sound.SetActive(true);
    }

    void DisableSound()
    {
        options.SetActive(true);
        sound.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableControls();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && sound.activeInHierarchy)
        {
            DisableSound();
        }

        if (options.activeInHierarchy)
        {
            menu.SetActive(false);
        }
    }

    void Start()
    {
        LoadSound();
    }
}
