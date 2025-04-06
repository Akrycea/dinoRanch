using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float currentTime;
    void Start()
    {
        currentTime = 100;
    }

    
    void Update()
    {
        //dodaæ ¿e time passing po rozpoczêciu rozgrywki dopiero
        timePassing();
    }

    //metoda mijania czasu
    void timePassing()
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
