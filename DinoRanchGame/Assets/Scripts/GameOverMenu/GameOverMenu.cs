using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TimeManager timeManager;
    public ClickManager clickManager;
   
    void Start()
    {
        gameObject.SetActive(false);
    }



    public void gameOver()
    {
        gameObject.SetActive(true);
        clickManager.canClickBG = false;
        timeManager.didGameStart = false;
    }

    public void tryAgainButton()
    {
        SceneManager.LoadScene(1);
    }

    public void exitButton()
    {
        SceneManager.LoadScene(0);
    }
}
