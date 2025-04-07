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
        //czeka a� zacznie si� gra aby zacz�� liczy� czas
        if (didGameStart)
        {
            timePassing();
        }
    }

    //metoda mijania czasu
    public void timePassing()
    {
        currentTime = currentTime - Time.deltaTime;


        //koniec dnia po sko�czeniu si� czasu
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
