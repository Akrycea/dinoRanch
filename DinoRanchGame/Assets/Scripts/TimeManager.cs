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
        //doda� �e time passing po rozpocz�ciu rozgrywki dopiero
        timePassing();
    }

    //metoda mijania czasu
    void timePassing()
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
