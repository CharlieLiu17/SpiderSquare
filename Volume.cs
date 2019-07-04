using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider volumeSlider;
    // Start is called before the first frame update
    private void Start()
    {
        mainMixer.SetFloat("volume", PlayerPrefs.GetFloat("Volume", 0));
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0);
    }
}
