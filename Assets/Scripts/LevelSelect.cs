using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    private Menumanager menuManager;

    void Start()
    {
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<Menumanager>();
    }

    public void LoadAlpha()
    {
        menuManager.LoadNewMenu("Track_AlphaTrack");
    }

    public void LoadBravo()
    {
        menuManager.LoadNewMenu("Track_BravoTrack");
    }

    public void Back()
    {
        menuManager.LoadNewMenu("MainMenu");
    }
}
