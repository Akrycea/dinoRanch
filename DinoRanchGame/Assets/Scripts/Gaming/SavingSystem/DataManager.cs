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
        //³adowanie rzeczy z data handler
        this.dinoData = dataHandler.Load();

        //jeœli nie by³o data do za³adowania to idzie do new game
        if(this.dinoData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

        //daæ data wszystkiemu co jej potrzebuje
        foreach(IDataManager dataManagerObj in dataManagerObjects)
        {
            dataManagerObj.LoadData(dinoData);
        }


        //zapisanie data u¿ywaj¹c dataHnadler
        dataHandler.Save(dinoData);

        Debug.Log("loeaded resources" + dinoData.WARM + dinoData.WATER + dinoData.FOOD);
        Debug.Log("loaded money" + dinoData.MONEY);
        Debug.Log("loaded tutorial status: " + dinoData.tutorialPlayed);
    }

    public void SaveGame()
    {
        //dodac przesy³anie data do innych skryptów
        foreach (IDataManager dataManagerObj in dataManagerObjects)
        {
            dataManagerObj.SaveData(ref dinoData);
        }
        // dodaæ zapisywanie data do oddzielnego file
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
