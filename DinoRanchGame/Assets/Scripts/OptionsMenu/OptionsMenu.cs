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
    public Sprite[] soundButtonSprites;
    public Button soundButton;

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
            soundButton.image.sprite = soundButtonSprites[0];
            
        }
        else
        {
            soundOn = false;
            musicManager.StopMusic();
            soundButton.image.sprite = soundButtonSprites[1];
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
