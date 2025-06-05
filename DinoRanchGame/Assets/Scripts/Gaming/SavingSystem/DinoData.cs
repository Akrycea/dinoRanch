using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DinoData
{
    //czy pojawi� si� ju� tutorial
    public bool tutorialPlayed;

    //resources 
    public float WARM;
    public float WATER;
    public float FOOD;
    public int MONEY;

    //pozycja kamery
    public Vector3 rightCameraTarget;


    //kupione dinozaury
    //public SerializableDictionary<string, bool> dinosCollected;

    //n dzia�a to na chama robimy!!!!!!
    public bool dino1bought;


    public DinoData()
    {
        tutorialPlayed = false;

        this.WARM = 30;
        this.WATER = 30;
        this.FOOD = 30;
        this.MONEY = 0;

        //nie wiem czemu ale n mo�na poda� rzeczywistego miejsca gdzie chcemy kamere
        //wi�c podane jest tak �eby jako� dzia�a�o
        //dont ask me why
        this.rightCameraTarget = new Vector3(40, 0, -10);

        //dinosCollected = new SerializableDictionary<string, bool>();

        dino1bought = false;



    }

}
