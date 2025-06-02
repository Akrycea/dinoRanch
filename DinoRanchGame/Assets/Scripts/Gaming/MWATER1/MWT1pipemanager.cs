using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class MWT1pipemanager : MonoBehaviour
{
    //zasoby
    public ResourcesManager RManager;
    public SpawnManager SManager;

    //potrzebne managery
    public ClickManager clickManager;

    //okno minigierki
    public GameObject[] MinigameObjects;

    //holds pipes
    public GameObject PipesHolder;
    public GameObject[] Pipes;
    int totalPipes = 0;



    int correctPipes;
    
    public int solution;
    
    void Start()
    {
        //solution = 0;

        //counts pipes (without the start and end ones)
        totalPipes = PipesHolder.transform.childCount;
        //holds all the pipes
        Pipes = new GameObject[totalPipes];

        //puts all the pipes into the array
        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }
    }

    public void StartMWater1()
    {
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(true);
        }
        RManager.minigameInProgress = true;

    }

    //this is supposed to be a win
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && solution == totalPipes)
        {   
           Debug.Log("you win");  
            MWater1End();
        }
    }

    //zakończenie gry
    void MWater1End()
    {


        //czeka chwilke z zamknięciem gry aby pokazac ile zdobyto zasobów
        StartCoroutine(waitingToEndGame());

        //dodaje zdobyte zasoby
        RManager.WATER = RManager.WATER + 40;

        //dodaje zdobytą kasę za opiekę
        SManager.money = SManager.money + 10;


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
       RManager.minigameInProgress = false;
        

    }
}
