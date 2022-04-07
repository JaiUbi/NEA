using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class PauseButton : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] settingsObjects;
    [SerializeField]
    public GameObject hideObject;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseObjects = GameObject.FindGameObjectsWithTag("PauseScreen");
        hidePaused();
        settingsObjects = GameObject.FindGameObjectsWithTag("OptionsMenu");
        hideSettingsMenu();
    }

    void Update()
    {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }


    //Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        pauseMenu.SetActive(true);
        //hideObject.SetActive(true);
        
        /*foreach (var g in pauseObjects)
        {
            g.SetActive(true);
        }
        */
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        pauseMenu.SetActive(false);
        hideObject.SetActive(false);
        
      /*  foreach (var g in pauseObjects)
        {
            g.SetActive(false);
        }
      */
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");

    }

    public void backToGame()
    {
        Time.timeScale = 0;
        hidePaused();
    }

    public void showSettingsMenu()
    {
        hideObject.SetActive(true);
        pauseMenu.SetActive(false);
      /*  foreach (var x in settingsObjects)
        {
            x.SetActive(true);
            
            
        }

        foreach (var g in pauseObjects)
        {
            g.SetActive(false);
        }
        */
        
    }
    
    public void hideSettingsMenu()
    {

        hideObject.SetActive(false);
        pauseMenu.SetActive(true);
        /*    foreach (var x in settingsObjects)
            {
                x.SetActive(false);
                
            }
    */
        /*      foreach (var g in pauseObjects)
              {
                  g.SetActive(true);
              }
      */

    }
    
    
    
    
    
    
    
}
