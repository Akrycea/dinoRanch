using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameObject optionsMenu;
    public OptionsMenu optionsCode;

    public GameObject credistMenu;
    public Credits creditsCode;

    public ClickManager clickManager;
    public TimeManager timeManager;
    
    void Start()
    {
        pauseMenu.SetActive(false); 
    }

    
    void Update()
    {
        
    }

    public void PauseMenuButton()
    {
        pauseMenu.SetActive(true);

        //wy³¹cza czas i klikanie BG
        timeManager.didGameStart = false;
        clickManager.canClickBG = false;
    }

    public void ClosePauseMenuButton()
    {
        pauseMenu.SetActive(false);

        //w³¹cza czas i klikanie BG
        timeManager.didGameStart = true;
        clickManager.canClickBG = true;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OptionsMenuButton()
    {
        optionsMenu.SetActive(true);
        optionsCode.fromPauseMenu = true;
        pauseMenu.SetActive(false);
    }

    public void CreditsMenuButton()
    {
        credistMenu.SetActive(true);
        pauseMenu.SetActive(false);
        creditsCode.fromPauseMenu = true;
        
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
