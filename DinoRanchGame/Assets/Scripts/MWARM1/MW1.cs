using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MW1 : MonoBehaviour
{   public ClickManager ClickManager;
    public int MW1_count;
    public GameObject[] MinigameObjects;
    public TMP_Text MW1gameText;

    public bool playingGame = false;

    [SerializeField] private float gameTimer;
    private bool timeStart;
  
    void Start()
    {
        
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }
        timeStart = false;
    }

    
    void Update()
    {
        if (timeStart)
        {
            ClickManager.canClickBG = false;
            MW1StartTimer();
            MWarm1Playing();
            MW1gameText.text = MW1_count + " fur gathered";
        }
        
    }

    //odpalenie gry
    public void StartMWarm1()
    {
        //odpala si� okienko gry
        foreach (var obj in MinigameObjects) 
        {
            obj.SetActive(true);
        }

        playingGame = true;
        MW1_count = 0;
        gameTimer = 0;
        timeStart = true;
       
    }

    //odpalamy czas
    private void MW1StartTimer()
    {    
        gameTimer = gameTimer + Time.deltaTime;
    }

    //co dzieje si� podczas gry
    void MWarm1Playing()
    {
        //tu zrobi� animacje futra latajacego na lewo i prawo bo jest odcinane lol

        //ko�cz gre po danym czasie
        if(gameTimer > 5)
        {
            Debug.Log("end game");
            MWarm1End();
        }
    }

    //zako�czenie gry
    void MWarm1End()
    {
        playingGame = false;

        StartCoroutine(waitingToEndGame());
        
        timeStart = false;
        ClickManager.canClickBG = true;
    }

    IEnumerator waitingToEndGame()
    {
        yield return new WaitForSeconds(4);
        //zamyka okienko gry
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }

    }
}
