using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostMenu : MonoBehaviour
{
    public SpawnManager spawnManager;
    public void BuyDino ()
    {
        if(gameObject.name == "Button")
        {
            Debug.Log("bought dino");
            spawnManager.spawn1BoughtDino();
        }
        else
        {
            Debug.Log(gameObject.name);
        }
    }
}
