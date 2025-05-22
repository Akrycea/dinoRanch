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
    public AudioSource audioSource;

    //dŸwiêk
    private bool soundOn;

    public bool fromPauseMenu;

    
    void Start()
    {
        optionsMenu.SetActive(false);
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
            audioSource.volume = 1f;
        }
        else
        {
            soundOn = false;
            audioSource.volume = 0f;
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
        }
    }
}
