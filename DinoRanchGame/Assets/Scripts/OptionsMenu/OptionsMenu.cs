using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject pauseMenu;

    //potrzebne managery
    public TimeManager timeManager;
    public ClickManager clickManager;


    //dŸwiêk
    private bool soundOn;
    public AudioSource musicSource;

    public bool fromPauseMenu;

    
    void Start()
    {
        optionsMenu.SetActive(false);
        musicSource = GameObject.Find("MusicSource").GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (optionsMenu.activeSelf) 
        {
            timeManager.didGameStart = false;
            clickManager.canClickBG = false;
        }

    }

    public void MuteSoundButton()
    {
        if (!soundOn) 
        {
            soundOn = true;
            musicSource.volume = 1.0f;
        }
        else
        {
            soundOn = false;
            musicSource.volume = 0.0f;
        }
    }

    public void GoBackButton()
    {
        if (fromPauseMenu)
        {
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(true);
            fromPauseMenu = false;
        }
        else
        {
            optionsMenu.SetActive(false);
            timeManager.didGameStart = true;
            clickManager.canClickBG = true;
        }
    }
}
