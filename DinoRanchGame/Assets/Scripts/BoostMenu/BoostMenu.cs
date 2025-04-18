using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostMenu : MonoBehaviour
{
    public SpawnManager spawnManager;
    Button button;
    private void Start()
    {
        button = gameObject.GetComponent<Button>();
    }
    public void BuyDino ()
    {
        //kupuje dino jesli wystarczajaca ma sie kasy
        if(gameObject.name == "Button" && spawnManager.money >= 10)
        {
            Debug.Log("bought dino");
            spawnManager.spawn1BoughtDino();
            button.enabled = false;
        }
        else
        {
            Debug.Log(gameObject.name);
            //button.enabled = false;
        }
        
    }

    public void skipToNextDay()
    {
        spawnManager.closeBoostUI();
    }
}
