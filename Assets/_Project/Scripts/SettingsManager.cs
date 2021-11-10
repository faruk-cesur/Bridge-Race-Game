using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private static SettingsManager _instance;
    public static SettingsManager Instance => _instance;

    public Slider sliderVibration;
    public Slider sliderAudio;

    public GameObject settingsPanel;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        FirstStart();
        Audio();
        sliderVibration.value = PlayerPrefs.GetFloat("Vibration");
        sliderAudio.value = PlayerPrefs.GetFloat("Audio");
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        UpdatePlayerPrefs();
        settingsPanel.SetActive(false);
        GameManager.Instance.RestartGame();
    }

    public void DefaultSettings()
    {
        sliderVibration.value = 1f;
        sliderAudio.value = 1f;
    }

    private void FirstStart()
    {
        if (!PlayerPrefs.HasKey("Vibration"))
        {
            DefaultSettings();
            UpdatePlayerPrefs();
        }
    }

    private void UpdatePlayerPrefs()
    {
        PlayerPrefs.SetFloat("Vibration", sliderVibration.value);
        PlayerPrefs.SetFloat("Audio", sliderAudio.value);
    }

    public void Vibration()
    {
        if (sliderVibration.value == 0)
        {
            Taptic.tapticOn = false;
        }
        else
        {
            Taptic.tapticOn = true;
        }
    }

    public void Audio()
    {
        if (sliderAudio.value == 0)
        {
            SoundManager.Instance.audioSource.mute = true;
        }
        else
        {
            SoundManager.Instance.audioSource.mute = false;
        }
    }
}