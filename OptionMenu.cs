using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public GameObject options;
    public GameObject dropdown;
    public GameObject main;
    public GameObject slider;

    public void Awake()
    {
        dropdown.GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt("Quality", 0);
        slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume", 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackButton();
        }
    }

    public void SetVolume(float vol)
    {
        mainMixer.SetFloat("volume", vol);
        PlayerPrefs.SetFloat("Volume", vol);
    }

    public void SetQuality(int qualIndex)
    {
        QualitySettings.SetQualityLevel(qualIndex);
        Debug.Log(QualitySettings.GetQualityLevel());
        PlayerPrefs.SetInt("Quality", qualIndex);
    }

    public void BackButton()
    {
        options.SetActive(false);
        main.SetActive(true);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        dropdown.GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt("Quality", 0);
        slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume", 0);
    }
}
