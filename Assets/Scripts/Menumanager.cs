using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menumanager : MonoBehaviour
{
    public string currentScene;

    public static event Action<string> sceneChange;
    void Start()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        currentScene = "MainMenu";
    }

    public void LoadNewMenu(string menuScene)
    {
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(menuScene, LoadSceneMode.Additive);
        currentScene = menuScene;
        sceneChange?.Invoke(menuScene);
    }

    void Update()
    {
        //print(currentScene.name);
    }


}
