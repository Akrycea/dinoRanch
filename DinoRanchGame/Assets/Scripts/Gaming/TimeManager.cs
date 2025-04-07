using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool didGameStart;
    public float currentTime;
    void Start()
    {
        currentTime = 10;
    }

    
    void Update()
    {
        //czeka a¿ zacznie siê gra aby zacz¹æ liczyæ czas
        if (didGameStart)
        {
            timePassing();
        }
    }

    //metoda mijania czasu
    public void timePassing()
    {
        currentTime = currentTime - Time.deltaTime;


        //koniec dnia po skoñczeniu siê czasu
        if ( currentTime <= 0)
        {
            dayEnds();
        }
    }

    //koniec dnia
    void dayEnds()
    {
        Debug.Log("day ended");
    }
}
