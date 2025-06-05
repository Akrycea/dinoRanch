using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingMenu : MonoBehaviour
{
    public DataManager dataManager;
    private void Start()
    {
        MusicManager.Instance.PlayMusic("MainMenu");
    }
    public void NewGame()
    {
        dataManager.Restart();
        SceneManager.LoadScene(1);

    }

    public void ContinueGame()
    {

        SceneManager.LoadScene(1);


    }

    public void quitGame()
    {
        Application.Quit();
    }
}
