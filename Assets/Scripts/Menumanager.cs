using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menumanager : MonoBehaviour
{
    Scene currentScene;
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
    }

    void Update()
    {
        
    }


}
