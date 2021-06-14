using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    Menumanager menumanager;
    [SerializeField] GameObject pauseMenuObject;
    void Start()
    {
        menumanager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<Menumanager>();
    }

    void OnEnable()
    {
        InputManager.MenuButtonEvent += HandleMenuEvent;
    }

    void OnDisable()
    {
        InputManager.MenuButtonEvent -= HandleMenuEvent;
    }

    public void LoadMainMenu()
    {
        Resume();
        menumanager.LoadNewMenu("MainMenu");
    }

    public void ResetTrack()
    {
        Resume();
        print("reset arg: " + menumanager.currentScene);
        menumanager.LoadNewMenu(menumanager.currentScene);
    }

    private void HandleMenuEvent()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Resume()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    private void Pause()
    {
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
}
