using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] menuMusic;
    [SerializeField] private AudioClip[] gameMusic;
    private AudioClip[] currentMusic;
    private AudioSource source;
    private int musicIndex = 0;
    private bool music = true;

    void Start()
    {
        currentMusic = menuMusic;
        source = GetComponent<AudioSource>();
        source.clip = currentMusic[musicIndex];
        if(music)
        {
            source.Play();
        }
    }

    void OnEnable()
    {
        Menumanager.sceneChange += HandleSceneChange;
    }

    void OnDisable()
    {
        Menumanager.sceneChange -= HandleSceneChange;
    }

    void Update()
    {
        if(music)
        {
            if(!source.isPlaying)
            {
                if(musicIndex > currentMusic.Length -1)
                {
                    musicIndex = 0;
                }

                source.clip = currentMusic[musicIndex];
                source.Play();
                musicIndex++;
            }
        } else
        {
            source.Pause();
        }
    }

    public void SetMusic(bool music)
    {
        this.music = music;
    }

    private void HandleSceneChange(string sceneName)
    {
        string[] splitString = sceneName.Split('_');
        if(splitString[0] == "Track")
        {
            currentMusic = gameMusic;
            musicIndex = 0;
            source.clip = currentMusic[musicIndex];
        }
    }
}
