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

    //rzeczy do minigierki
    public ClickManager ClickManager;
    public GameObject[] MinigameObjects;
    public int MF1berries_count;
    public TMP_Text MF1gameText;
    public GameObject BerryPrefab;

    [SerializeField] private float gameTimer;
    private bool timeStart;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }
        timeStart = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart)
        {
            ClickManager.canClickBG = false;
            MF1StartTimer();
            MFood1Playing();
            //if (MW1_count >= 1)
            //{
            //    MW1gameText.text = MW1_count + " berries";
           // }
        
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
        MF1berries_count=0;
        gameTimer=10;
        timeStart=true;
        Invoke("SpawnFirstFiveBerries",0f);
        InvokeRepeating("BerrySpawner",2f,2f);
    }

    void SpawnFirstFiveBerries()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-2f,2f),UnityEngine.Random.Range(0f,3f), 0f);
            Instantiate(BerryPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }
    void BerrySpawner()
    {
            Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-2f,2f),UnityEngine.Random.Range(0f,3f),0f);
            Instantiate(BerryPrefab,randomSpawnPosition,Quaternion.identity);
    }

    void MFood1Playing()
    {
        if (gameTimer < 0)
        {
            Debug.Log("end game");
            MFood1End();

        }
    }
    void MFood1End()
    {
        timeStart=false;
        RManager.FOOD= RManager.FOOD + MF1berries_count;
        StartCoroutine(waitingToEndGame());
        ClickManager.canClickBG=true;
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

    }
}
