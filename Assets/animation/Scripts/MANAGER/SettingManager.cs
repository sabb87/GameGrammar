using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingManager : MonoBehaviour
{
    [Header("Music")]
    public Slider musicSlider;
    public TMP_Text musicValueText;

    [Header("Sound Effect")]
    public Slider sfxSlider;
    public TMP_Text sfxValueText;

    private void Start()
    {
        // Load volume dari AudioManager
        musicSlider.value = AudioManager.Instance.bgmVolume;
        sfxSlider.value = AudioManager.Instance.sfxVolume;

        UpdateMusicVolume(musicSlider.value);
        UpdateSFXVolume(sfxSlider.value);

        // Event Slider
        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
        sfxSlider.onValueChanged.AddListener(UpdateSFXVolume);
    }

    public void UpdateMusicVolume(float value)
    {
        AudioManager.Instance.SetBGMVolume(value);
        musicValueText.text = Mathf.RoundToInt(value * 100) + "%";
    }

    public void UpdateSFXVolume(float value)
    {
        AudioManager.Instance.SetSFXVolume(value);
        sfxValueText.text = Mathf.RoundToInt(value * 100) + "%";
    }
}