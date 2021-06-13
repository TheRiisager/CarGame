using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public bool sound, music;
    public Sprite onSprite, offSprite;
   // public SpriteRenderer musicRender, soundRender;
    public Button button_sound, button_music;
    private Menumanager menuManager;
    private MusicManager musicManager;

    private void Start()
    {
        sound = true;
        music = true;
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<Menumanager>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
    }
    public void button_Start()
    {
        menuManager.LoadNewMenu("LevelSelect");
    }

    public void button_Controls()
    {
        //SceneManager.LoadScene("CONTROL-SCENE");
    }

    public void button_Music()
    {
        if (music)
        {
            music = false;
            musicManager.SetMusic(false);
            button_music.image.sprite = offSprite;
        }
        else
        {
            music = true;
            musicManager.SetMusic(true);
            button_music.image.sprite = onSprite;
        }
    }

    public void button_Sound()
    {
        if (sound)
        {
            sound = false;
            button_sound.image.sprite = offSprite;
        }
        else
        {
            sound = true;
            button_sound.image.sprite = onSprite;
        }
    }

    public void button_Highscore()
    {
        menuManager.LoadNewMenu("Scoreboard");
    }

    public void button_Exit()
    {
        Application.Quit();
    }

}
