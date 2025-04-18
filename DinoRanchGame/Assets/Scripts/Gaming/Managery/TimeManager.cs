using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    public bool didGameStart;
    public float currentTime;
    public TMP_Text timer;
    public ClickManager clickManager;
    public SpawnManager spawnManager;
    void Start()
    {
        didGameStart = false;
        currentTime = 30;
        timer.text = currentTime.ToString("0");
    }

    
    void Update()
    {
        //czeka a¿ zacznie siê gra aby zacz¹æ liczyæ czas
        if (didGameStart && currentTime > 0)
        {
            timePassing();
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
        if ( currentTime <= 0)
        {
            dayEnds();
        }
    }

    //koniec dnia
    void dayEnds()
    {
        clickManager.canClickBG = false;
        didGameStart = false;

        //w³¹cza boost ui
        spawnManager.openBoostWindow();
        Debug.Log("day ended");
    }

    public void resetTime()
    {
        currentTime = 30;
    }
}
