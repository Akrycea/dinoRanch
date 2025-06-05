using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostMenu : MonoBehaviour
{
    public DataManager dataManager;
    public ResourcesManager resourcesManager;
    public SpawnManager spawnManager;
    public TimeManager timeManager;
    Button button;

    
    private void Start()
    {
        button = gameObject.GetComponent<Button>();
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            timeManager.didGameStart = false;
        }
        else
        {
            timeManager.didGameStart = true;
        }
    }
    public void BuyDino ()
    {
        //kupuje dino jesli wystarczajaca ma sie kasy
        if(gameObject.name == "Button" && spawnManager.money >= 10)
        {
            Debug.Log("bought dino");
            //spawnuje dino
            spawnManager.spawn1BoughtDino();
            

            //mówi ¿e resources dostaj¹ boosta
            resourcesManager.boost1Active = true;
            resourcesManager.resourcesBoosted = true;

            //wy³¹cza mo¿liwoœæ klikniêcia przycisku
            button.enabled = false;

            dataManager.SaveGame();
        }
        else
        {
            Debug.Log(gameObject.name);
            //button.enabled = false;
        }
        
    }

    public void skipToNextDay()
    {
        dataManager.SaveGame();
        spawnManager.closeBoostUI();
        
    }

    
}
