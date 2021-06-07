using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] musicCollection;
    private AudioSource source;
    private int musicIndex = 0;
    private bool music = true;
    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = musicCollection[musicIndex];
        if(music)
        {
            source.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(music)
        {
            if(!source.isPlaying)
            {
                if(musicIndex > musicCollection.Length -1)
                {
                    musicIndex = 0;
                }

                source.clip = musicCollection[musicIndex];
                source.Play();
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
}
