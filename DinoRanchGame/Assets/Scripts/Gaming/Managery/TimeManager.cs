using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    //zaczyna gre
    public bool didGameStart;

    //obecny czas
    public float currentTime;

    //UI czasu
    public TMP_Text timer;

    //managery
    public ClickManager clickManager;
    public SpawnManager spawnManager;
    public ResourcesManager resourcesManager;
    void Start()
    {
        didGameStart = false;
        currentTime = 60;
        timer.text = currentTime.ToString("0");
    }

    
    void Update()
    {
        if (didGameStart)
        {
            Debug.Log("started game");
        }
        //czeka a¿ zacznie siê gra aby zacz¹æ liczyæ czas
        if (didGameStart && currentTime > 0)
        {
            timePassing();
        }

        if (currentTime <= 0)
        {
            if (resourcesManager.minigameInProgress == false)
            {
                dayEnds();
            }
        }
    }

    //metoda mijania czasu
    public void timePassing()
    {
        //odejmuje od czasu przy ka¿dej klatce
        currentTime = currentTime - Time.deltaTime;


        //pokazuje ile czasu na UI
        timer.text = currentTime.ToString("0");

        //koniec dnia po skoñczeniu siê czasu
        
    }

    //koniec dnia
    public void dayEnds()
    {
        clickManager.canClickBG = false;
        didGameStart = false;

        //w³¹cza boost ui
        spawnManager.openBoostWindow();
        Debug.Log("day ended");
    }

    public void resetTime()
    {
        currentTime = 60;
    }


    ////DO £ADOWANIA I ZAPISYWANIA GRY
    //public void LoadData(DinoData data)
    //{
    //    this.currentTime = data.TIME;
    //}

    //public void SaveData(ref DinoData data)
    //{
    //    data.TIME = this.currentTime;
    //}
}
