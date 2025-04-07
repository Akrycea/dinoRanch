using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    public TimeManager timeManager;

    //resources set
    public float WARM;
    public float FOOD;
    public float WATER;

    //slidery zasob�w
    public Slider sliderW;
    public Slider sliderWat;
    public Slider sliderF;

    void Start()
    {
        //ile jest zasob�w na pocz�tku
        WARM = 100;
        FOOD = 100;
        WATER = 100;

        //max i min slider�w
        sliderW.maxValue = 100;
        sliderW.minValue = 0;

        sliderWat.maxValue = 100;
        sliderWat.minValue = 0;

        sliderF.maxValue = 100;
        sliderF.minValue = 0;

    }


    void Update()
    {
        //spadanie ilo�ci zasob�w z czasem
        if(timeManager.currentTime >0 && timeManager.didGameStart)
        {
            WARM = WARM - Time.deltaTime/2;
            FOOD = FOOD - Time.deltaTime / 2;
            WATER = WATER - Time.deltaTime / 2;
        }

        //odpalenie slider�w
        sliderWarm();
        sliderWater();
        sliderFood();

        //pilnuje �eby nie by�o wi�cej ni� max zasob�w
        if(WARM > 100)
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


    //slider WARM
    public void sliderWarm()
    {
        sliderW.value = WARM;
        
    }

    //slider WATER
    public void sliderWater()
    {
        sliderWat.value = WATER;
    }

    //slider FOOD
    public void sliderFood()
    {
        sliderF.value = FOOD;
    }

}
