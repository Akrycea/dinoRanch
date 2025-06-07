using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Xml.Linq;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class MF1 : MonoBehaviour
{
     //zasoby
    public ResourcesManager RManager;
    public SpawnManager spawnManager;

    //rzeczy do minigierki
    public ClickManager ClickManager;
    public GameObject[] MinigameObjects;
    public int MF1berries_count;
    public TMP_Text MF1gameText;
    public GameObject BerryPrefab;
    private Vector3 minigamePlace;

    [SerializeField] private float gameTimer;
    private bool timeStart;

   
    void Start()
    {
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }
        
        timeStart = false;

        MF1gameText.text = "Grab and throw berries into the basket!";


    }

   
    void Update()
    {
        if (timeStart)
        {
            RManager.minigameInProgress = true;
            minigamePlace = gameObject.transform.position;
            ClickManager.canClickBG = false;
            MF1StartTimer();
            MFood1Playing();
            if (MF1berries_count >= 1)
            {
                MF1gameText.text = "Gathered " + MF1berries_count + " berries";
            }

        }
    
    }
    

    void MF1StartTimer()
    {
        gameTimer = gameTimer - Time.deltaTime;
        
    }

    public void StartMF1()
    {
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(true);
        }

        //ustawia rzeczy do gry
        MF1berries_count = 0;
        gameTimer = 13;
        timeStart = true;
        

        //spawnuje berries
        Invoke("SpawnFirstFiveBerries",0f);
        InvokeRepeating("BerrySpawner", 1f, 0.3f);
    }

    void SpawnFirstFiveBerries()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-2f,2f),UnityEngine.Random.Range(0f,3f), 0f);
            Instantiate(BerryPrefab, minigamePlace + randomSpawnPosition, Quaternion.identity);
        }
    }
    void BerrySpawner()
    {
            Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-3f,3f),UnityEngine.Random.Range(0f,3f),0f);
            Instantiate(BerryPrefab, minigamePlace + randomSpawnPosition, Quaternion.identity);
    }

    void MFood1Playing()
    {
        if (gameTimer < 0)
        {
            Debug.Log("end minigame");
            MFood1End();

        }
    }
    void MFood1End()
    {
        timeStart = false;

        RManager.FOOD= RManager.FOOD + MF1berries_count + 10;
        spawnManager.money = spawnManager.money + MF1berries_count;

        StartCoroutine(waitingToEndGame());

        ClickManager.canClickBG = true;

        DestroyBerries();

        CancelInvoke("BerrySpawner");
    }
    void DestroyBerries()
    {
        GameObject[] berries = GameObject.FindGameObjectsWithTag("Berry");
        foreach (GameObject berry in berries)
        {
            Destroy(berry);
        }
    }
    IEnumerator waitingToEndGame()
    {
        yield return new WaitForSeconds(3);
        //zamyka okienko gry
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }
        RManager.minigameInProgress = false;

    }
}
