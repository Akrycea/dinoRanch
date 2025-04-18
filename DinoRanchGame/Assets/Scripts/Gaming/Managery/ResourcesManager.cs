using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesManager : MonoBehaviour
{
    public TimeManager timeManager;

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
        WARM = 100;
        FOOD = 100;
        WATER = 100;

    }


    void Update()
    {
        //spadanie iloœci zasobów z czasem
        if(timeManager.currentTime >0 && timeManager.didGameStart)
        {
            WARM = WARM - Time.deltaTime/2;
            FOOD = FOOD - Time.deltaTime / 2;
            WATER = WATER - Time.deltaTime / 2;
        }

        //robienie float na liczby ca³kowite
        warmCount.text = WARM.ToString("0");
        waterCount.text = WATER.ToString("0");
        foodCount.text = FOOD.ToString("0");

        //pilnuje ¿eby nie by³o wiêcej ni¿ max zasobów
        if (WARM > 100)
        {
            WARM = 100;
        }
        if (FOOD > 100)
        {
            FOOD = 100;
        }
        if (WATER > 100)
        {
            WATER = 100;
        }

    }

    //resetuje resources (u¿yte przy odpalaniu kolejnego dnia)
    public void resetResources()
    {
        WARM = 100;
        FOOD = 100;
        WATER = 100;
    }


}
