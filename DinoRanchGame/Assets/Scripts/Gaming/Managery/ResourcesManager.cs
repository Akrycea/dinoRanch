using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesManager : MonoBehaviour, IDataManager
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
    public float WATER ;

    //liczba zasobów pokazywana na UI
    public TMP_Text warmCount;
    public TMP_Text waterCount;
    public TMP_Text foodCount;

    void Start()
    {
        //ile jest zasobów na pocz¹tku
        //WARM = 30;
        //FOOD = 30;
        //WATER = 30;

        //wy³¹cza boosty
        resourcesBoosted = false;
        boost1Active = false;

        minigameInProgress = false;

    }


    void Update()
    {
        usingResourses();

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

        //konczy gre kiedy skoncza sie zasoby
        if(WARM < 0 || FOOD < 0 || WATER < 0 )
        {
            if (!minigameInProgress)
            {
                Debug.Log("ending game because of low resources");
                gameOverMenu.gameOver();
            }
            
        }
    }

    private void usingResourses()
    {
        //spadanie iloœci zasobów z czasem bez boostow
        if(timeManager.currentTime >0 && timeManager.didGameStart)
        {
            WARM = WARM - Time.deltaTime * 1.5f;
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


    //DO £ADOWANIA I ZAPISYWANIA GRY
    public void LoadData(DinoData data)
    {
       this.WARM = data.WARM;
       this.WATER = data.WATER;
       this.FOOD = data.FOOD;
    }

    public void SaveData(ref DinoData data)
    {
        data.WARM = this.WARM;
        data.WATER = this.WATER;
        data.FOOD = this.FOOD;
    }


}
