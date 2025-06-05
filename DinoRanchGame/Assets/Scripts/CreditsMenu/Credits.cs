using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject creditsMenu;
    public GameObject pasueMenu;

    public TimeManager timeManager;
    public ClickManager clickManager;

    public bool fromPauseMenu;
    
    void Start()
    {
        creditsMenu.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (fromPauseMenu == true)
            {
                creditsMenu.SetActive(false);
                pasueMenu.SetActive(true);
                fromPauseMenu = false;
            }
            else
            {
                creditsMenu.SetActive(false);
                timeManager.didGameStart = true;
                clickManager.canClickBG = true;
            }
        }
    }
}
