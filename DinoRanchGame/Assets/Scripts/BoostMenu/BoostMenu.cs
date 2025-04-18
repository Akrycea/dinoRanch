using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostMenu : MonoBehaviour
{
    public ResourcesManager resourcesManager;
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
            //spawnuje dino
            spawnManager.spawn1BoughtDino();

            //m�wi �e resources dostaj� boosta
            resourcesManager.boost1Active = true;
            resourcesManager.resourcesBoosted = true;

            //wy��cza mo�liwo�� klikni�cia przycisku
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
