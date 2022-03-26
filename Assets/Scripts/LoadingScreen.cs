using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    public static LoadingScreen instance;

    public GameObject loadingScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        instance = this;

        SceneManager.LoadScene((int)SceneIndexEnums.PreviewScene, LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        loadingScene.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync((int) SceneIndexEnums.PreviewScene);
        SceneManager.LoadSceneAsync((int) SceneIndexEnums.LoginPage, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync((int) SceneIndexEnums.MenuScene, LoadSceneMode.Additive);

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
