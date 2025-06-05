using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject pauseMenu;

    //potrzebne managery
    public TimeManager timeManager;
    public ClickManager clickManager;


    //dŸwiêk
    private bool soundOn;
    private MusicManager musicManager;


    public bool fromPauseMenu;

    
    void Start()
    {
        optionsMenu.SetActive(false);
        musicManager = GameObject.Find("SoundManager").GetComponent<MusicManager>();

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
            musicManager.PlayMusic("MainMenu");

            
        }
        else
        {
            soundOn = false;
            musicManager.StopMusic();

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
