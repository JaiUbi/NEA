using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Music : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public int Volume;
    

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
        Debug.Log(PlayerPrefs.GetFloat("MusicVolume").ToString());

        if (slider.value < 0.000000011)
        {
            mixer.SetFloat("MusicVolume", -100f);
        }
        

    }

    public void SetLevel()
    {
        if (PlayerPrefs.GetFloat("MusicVolume")== 1E-08f) {
            mixer.SetFloat("MusicVolume", -1000f);
        }
        float sliderValue = slider.value;
        if (slider.value > 0.000000011)
        {
            mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
            PlayerPrefs.SetFloat("MusicVolume", sliderValue);
            
        }

        else
        {
            mixer.SetFloat("MusicVolume", -1000f);
            PlayerPrefs.SetFloat("MusicVolume", sliderValue);
            
        }
    }


}