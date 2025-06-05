using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;


    private DinoData dinoData;

    private List<IDataManager> dataManagerObjects;

    private FileDataHandler dataHandler;

    public static DataManager instance { get; private set; }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found one than one DataManager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataManagerObjects = FindAllDataManagerObjects();
        LoadGame();
        
    }

    public void NewGame()
    {
        this.dinoData = new DinoData();
    }

    public void LoadGame()
    {
        //�adowanie rzeczy z data handler
        this.dinoData = dataHandler.Load();

        //je�li nie by�o data do za�adowania to idzie do new game
        if(this.dinoData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

        //da� data wszystkiemu co jej potrzebuje
        foreach(IDataManager dataManagerObj in dataManagerObjects)
        {
            dataManagerObj.LoadData(dinoData);
        }


        //zapisanie data u�ywaj�c dataHnadler
        dataHandler.Save(dinoData);

        Debug.Log("loeaded resources" + dinoData.WARM + dinoData.WATER + dinoData.FOOD);
        Debug.Log("loaded money" + dinoData.MONEY);
        Debug.Log("loaded tutorial status: " + dinoData.tutorialPlayed);
    }

    public void SaveGame()
    {
        //dodac przesy�anie data do innych skrypt�w
        foreach (IDataManager dataManagerObj in dataManagerObjects)
        {
            dataManagerObj.SaveData(ref dinoData);
        }
        // doda� zapisywanie data do oddzielnego file
        dataHandler.Save(dinoData);

        Debug.Log("saved resources" + dinoData.WARM + dinoData.WATER + dinoData.FOOD);
        Debug.Log("saved money" + dinoData.MONEY);
        Debug.Log("saved tutorial status: " + dinoData.tutorialPlayed);
    }

    public void Restart()
    {
        dataHandler.Restart(dinoData);
    }


    private List<IDataManager> FindAllDataManagerObjects()
    {
        IEnumerable<IDataManager> dataManagerObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataManager>();
        return new List<IDataManager>(dataManagerObjects);
    }
}
