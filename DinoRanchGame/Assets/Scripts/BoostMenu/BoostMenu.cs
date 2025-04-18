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
        //dodaæ ¿e jeszcze musi ci starczyæ kasy na to
        if(gameObject.name == "Button")
        {
            Debug.Log("bought dino");
            spawnManager.spawn1BoughtDino();
            //button.enabled = false;
        }
        else
        {
            Debug.Log(gameObject.name);
        }
        button.enabled = false;
    }
}
