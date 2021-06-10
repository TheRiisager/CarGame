using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menumanager : MonoBehaviour
{
    Scene currentScene;

    public static event Action<string> sceneChange;
    void Start()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        currentScene = SceneManager.GetSceneByName("MainMenu");
    }

    public void LoadNewMenu(string menuScene)
    {
        SceneManager.UnloadSceneAsync(currentScene.name);
        SceneManager.LoadSceneAsync(menuScene, LoadSceneMode.Additive);
        currentScene = SceneManager.GetSceneByName(menuScene);
        sceneChange?.Invoke(menuScene);
    }

    void Update()
    {
        
    }


}
