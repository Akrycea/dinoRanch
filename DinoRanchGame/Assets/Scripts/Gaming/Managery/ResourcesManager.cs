using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesManager : MonoBehaviour
{
    public TimeManager timeManager;
    public GameOverMenu gameOverMenu;

    //bool czy jeste�my w trakcie minigierki
    public bool minigameInProgress = true;

    //bool czy dziala jakis boost
    public bool resourcesBoosted;
    //boole wszytskich isntiejacyh boostow
    [HideInInspector] public bool boost1Active;

    //resources set
    public float WARM;
    public float FOOD;
    public float WATER;

    //liczba zasob�w pokazywana na UI
    public TMP_Text warmCount;
    public TMP_Text waterCount;
    public TMP_Text foodCount;

    void Start()
    {
        //ile jest zasob�w na pocz�tku
        WARM = 30;
        FOOD = 30;
        WATER = 30;

        //wy��cza boosty
        resourcesBoosted = false;
        boost1Active = false;

    }


    void Update()
    {
        usingResourses();

        //robienie float na liczby ca�kowite
        warmCount.text = WARM.ToString("0");
        waterCount.text = WATER.ToString("0");
        foodCount.text = FOOD.ToString("0");

        //pilnuje �eby nie by�o wi�cej ni� max zasob�w
        if (WARM > 30)
        {
            WARM = 30;
        }
        if (FOOD > 30)
        {
            FOOD = 30;
        }
        if (WATER > 30)
        {
            WATER = 30;
        }

        //konczy gre kiedy skoncza sie zasoby
        if(WARM < 0 && !minigameInProgress || FOOD < 0 && !minigameInProgress || WATER < 0 && !minigameInProgress)
        {
            gameOverMenu.gameOver();
        }
    }

    private void usingResourses()
    {
        //spadanie ilo�ci zasob�w z czasem bez boostow
        if(timeManager.currentTime >0 && timeManager.didGameStart)
        {
            WARM = WARM - Time.deltaTime * 2;
            FOOD = FOOD - Time.deltaTime / 2;
            WATER = WATER - Time.deltaTime / 4;

            // zmienia pr�dko�� spadania zasob�w, sprawdza kt�ryboost ma wybra� i to robi
            if (resourcesBoosted && boost1Active)
            {
                WARM = WARM + Time.deltaTime * 1.5f;
            }
        }
    }

    //resetuje resources (u�yte przy odpalaniu kolejnego dnia)
    public void resetResources()
    {
        WARM = 30;
        FOOD = 30;
        WATER = 30;
    }


}
