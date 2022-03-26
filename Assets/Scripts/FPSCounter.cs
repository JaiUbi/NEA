using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{

    public TMP_Text counter;
    public GameObject counterObject;

    private float updateTime = 1f;
    private float time;
    private int frameCount;
    

    // Update is called once per frame
    void Update()
    {
        counterObject.SetActive(true);

        if (PlayerPrefs.GetInt("FPS") == 0)
        {            
            counterObject.SetActive(true);

        }

        time += Time.deltaTime;
        frameCount++;

        if (time >= updateTime)
        {
            var frameRate = Mathf.RoundToInt(frameCount / time);
            counter.text = $"{frameRate} FPS";

            time -= updateTime;
            frameCount = 0;

        }
    }
    
    
    
    
}
