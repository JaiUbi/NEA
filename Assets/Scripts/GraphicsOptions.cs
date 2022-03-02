using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GraphicsOptions : MonoBehaviour
{
    public Toggle fullscreenToggle, vsyncToggle;

    public List<ResItem> resolutions = new List<ResItem>();

    private int selectedRes;

    public TMP_Text resLabel;


    // Start is called before the first frame update
    void Start()
    {

        fullscreenToggle.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncToggle.isOn = false;
            
        }
        else
        {
            vsyncToggle.isOn = true;
        }

        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedRes = i;
                UpdateResLabel();
            }
    }

        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;
            resolutions.Add(newRes);
            selectedRes = resolutions.Count - 1;
            UpdateResLabel();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        selectedRes--;
        if (selectedRes < 0)
        {
            selectedRes = resolutions.Count - 1;
        }
        
        UpdateResLabel();
        
    }

    public void ResRight()
    {
        selectedRes++;
        if (selectedRes > resolutions.Count - 1)
        {
            selectedRes = 0;
        }
        
        UpdateResLabel();

    }

    public void UpdateResLabel()
    {
        resLabel.text = resolutions[selectedRes].horizontal.ToString() + " X " +
                        resolutions[selectedRes].vertical.ToString();
    }
    
    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullscreenToggle.isOn;
        if (vsyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
            
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolutions[selectedRes].horizontal, resolutions[selectedRes].vertical,
            fullscreenToggle.isOn);


    }
    
}
[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
