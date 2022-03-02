using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEditor;

public class LandingScreen : MonoBehaviour
{

    public AudioMixer mixer1;
    public int SceneNo = 0;
    public Button ClickToPlay;
    //public float timer;

    //public TMP_Text LandingText;

    // Start is called before the first frame update
    void Start()
    {


        Debug.Log(PlayerPrefs.GetFloat("MusicVolume"));
        mixer1.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume"))*20);


    }

    // Update is called once per frame
    void Update()
    { 
        /*
         timer += Time.deltaTime;
        if (timer <= 0.2)
        {
            LandingText.enabled = true;
        }

        if (!(timer >= 1.5)) return;
        LandingText.enabled = false;
        timer = 0;
        */
    }

    public void onClickEvent()
    {
        SceneManager.LoadScene("MenuScene");
        SceneNo = 1;

    }

    
}