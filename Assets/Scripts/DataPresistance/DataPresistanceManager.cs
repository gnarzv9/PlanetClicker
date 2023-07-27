using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataPresistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPresistance> dataPersistanceObjects;

    private FileDataHandler dataHandler;

    public static DataPresistanceManager instance { get; private set; }


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;    
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //TODO - Load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        // if no data can be loaded , initalize to a new game
        if(this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }
        
        //TODO - push the loaded data to all other scripts that need it
        foreach(IDataPresistance dataPersistenceObj in dataPersistanceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        //TODO - pass the data to other scripts so they can update it
        foreach (IDataPresistance dataPersistenceObj in dataPersistanceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        //TODO - save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPresistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPresistance> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPresistance>();

        return new List<IDataPresistance>(dataPersistenceObjects);
    }

}
