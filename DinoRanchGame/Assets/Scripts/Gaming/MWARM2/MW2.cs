using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MW2 : MonoBehaviour
{
    //zasoby
    public ResourcesManager RManager;

    //rzeczy do minigierki
    public ClickManager clickManager;
    public SpawnManager spawnManager;

    //wynik gierki
    public float MW2_count;

    //UI gierki
    public GameObject[] MinigameObjects;
    public GameObject[] MinigameShapes;
    public TMP_Text MW2gameText;


    public bool playingGame = false;

    [SerializeField] private float gameTimer;
    private bool timeStart;

    void Start()
    {

        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }
        foreach (var obj in MinigameShapes)
        {
            obj.SetActive(false);
        }
        timeStart = false;
    }


    void Update()
    {
        
        if (timeStart)
        {
            RManager.minigameInProgress = true;
            clickManager.canClickBG = false;
            MW2StartTimer();
            MWarm2Playing();
            if (MW2_count >= 1)
            {
                MW2gameText.text = "Shave the shape! " + ((MW2_count / 500) * 100).ToString("0") + "%";
            }

            
        }

    }

    //odpalenie gry
    public void StartMWarm2()
    {
        //odpala się okienko gry
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(true);
        }


        //odpala pierwszy shape
        MinigameShapes[0].SetActive(true);

        //text sie zmienia
        MW2gameText.text = "Follow the pattern!";

        //mówi że gierka sie zaczęła i zeruje co trzeba
        playingGame = true;
        MW2_count = 0;
        gameTimer = 0;
        timeStart = true;


    }

    //odpalamy czas
    private void MW2StartTimer()
    {
        gameTimer = gameTimer + Time.deltaTime;
    }

    //co dzieje sie podczas gry
    void MWarm2Playing()
    {
        MinigameShapes[0].SetActive(true);
        
        //sprawdza wynik i odpala dany shape
        if (MW2_count >= 200)
        {
            MinigameShapes[0].SetActive(false);
            MinigameShapes[1].SetActive(true);
            

            if (MW2_count >= 350)
            {
                MinigameShapes[1].SetActive(false);
                MinigameShapes[2].SetActive(true);
                

                if (MW2_count >= 500)
                {
                    MinigameShapes[2].SetActive(false);
                    MinigameShapes[3].SetActive(true);
                    
                }
            }
        }
        
        //koncz gre po zrobieniu wszystkich shapes
        if (MW2_count >= 500)
        {
            MWarm1End();
        }
    }

    //zakonczenie gry
    void MWarm1End()
    {

        playingGame = false;

        //czeka chwilke z zamknieciem gry aby pokazac ile zdobyto zasob�w
        StartCoroutine(waitingToEndGame());

        timeStart = false;

        //dodaje zdobyte zasoby
        RManager.WARM = RManager.WARM + 30;

        //dodaje zdobytą kasę za opiekę
        spawnManager.money = spawnManager.money + 10;


        //przywraca klikanie na tło
        clickManager.canClickBG = true;


    }

    IEnumerator waitingToEndGame()
    {
        yield return new WaitForSeconds(1);
        //zamyka okienko gry
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }

        foreach (var obj in MinigameShapes)
        {
            obj.SetActive(false);
        }
        RManager.minigameInProgress = false;


    }
}
