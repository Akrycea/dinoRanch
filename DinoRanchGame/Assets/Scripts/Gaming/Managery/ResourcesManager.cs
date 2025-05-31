using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesManager : MonoBehaviour
{
    public TimeManager timeManager;
    public GameOverMenu gameOverMenu;

    //bool czy jesteœmy w trakcie minigierki
    public bool minigameInProgress = true;

    //bool czy dziala jakis boost
    public bool resourcesBoosted;
    //boole wszytskich isntiejacyh boostow
    [HideInInspector] public bool boost1Active;

    //resources set
    public float WARM;
    public float FOOD;
    public float WATER;

    //liczba zasobów pokazywana na UI
    public TMP_Text warmCount;
    public TMP_Text waterCount;
    public TMP_Text foodCount;

    void Start()
    {
        //ile jest zasobów na pocz¹tku
        WARM = 30;
        FOOD = 30;
        WATER = 30;

        //wy³¹cza boosty
        resourcesBoosted = false;
        boost1Active = false;

    }


    void Update()
    {
        usingResourses();

        //robienie float na liczby ca³kowite
        warmCount.text = WARM.ToString("0");
        waterCount.text = WATER.ToString("0");
        foodCount.text = FOOD.ToString("0");

        //pilnuje ¿eby nie by³o wiêcej ni¿ max zasobów
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
        //spadanie iloœci zasobów z czasem bez boostow
        if(timeManager.currentTime >0 && timeManager.didGameStart)
        {
            WARM = WARM - Time.deltaTime * 2;
            FOOD = FOOD - Time.deltaTime / 2;
            WATER = WATER - Time.deltaTime / 4;

            // zmienia prêdkoœæ spadania zasobów, sprawdza któryboost ma wybraæ i to robi
            if (resourcesBoosted && boost1Active)
            {
                WARM = WARM + Time.deltaTime * 1.5f;
            }
        }
    }

    //resetuje resources (u¿yte przy odpalaniu kolejnego dnia)
    public void resetResources()
    {
        WARM = 30;
        FOOD = 30;
        WATER = 30;
    }


}
