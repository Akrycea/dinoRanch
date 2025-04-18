using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesManager : MonoBehaviour
{
    public TimeManager timeManager;
    public GameOverMenu gameOverMenu;

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

    }


    void Update()
    {
        //spadanie iloœci zasobów z czasem
        if(timeManager.currentTime >0 && timeManager.didGameStart)
        {
            WARM = WARM - Time.deltaTime * 3;
            FOOD = FOOD - Time.deltaTime / 2;
            WATER = WATER - Time.deltaTime / 4;
        }

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
        if(WARM < 0 || FOOD < 0 || WATER < 0)
        {
            gameOverMenu.gameOver();
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
