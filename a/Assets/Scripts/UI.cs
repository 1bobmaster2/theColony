using System;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject sound;
    [SerializeField] private GameObject fpsMenu;
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
            if (Application.isEditor)
            {
                Debug.Log(SoundVolume + " also found the player pref");
            }
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
        if (controls.activeSelf)
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

    public void EnableFpsMenu()
    {
        fpsMenu.SetActive(true);
        options.SetActive(false);
    }

    void DisableFpsMenu()
    {
        fpsMenu.SetActive(false);
        options.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && controls.activeSelf)
        {
            DisableControls();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && options.activeSelf)
        {
            DisableOptions();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && fpsMenu.activeSelf)
        {
            DisableFpsMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && sound.activeSelf)
        {
            DisableSound();
        }

        if (options.activeSelf)
        {
            menu.SetActive(false);
        }
    }

    void Start()
    {
        LoadSound();
        LoadMaxFps();
    }
    

    public void SetMaxFps(string valueString)
    {
        int value = int.Parse(valueString);
        QualitySettings.vSyncCount = 0;
        if (value == 0)
        {
            Application.targetFrameRate = -1;
        }
        else
        {
            Application.targetFrameRate = value;
            PlayerPrefs.SetInt("MaxFps", value);
        }
    }

    void LoadMaxFps()
    {
        if (PlayerPrefs.HasKey("MaxFps"))
        {
            Application.targetFrameRate = PlayerPrefs.GetInt("MaxFps");
        }
    }
}
