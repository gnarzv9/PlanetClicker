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
        // Check if dataPersistanceObjects is null or empty
        if (dataPersistanceObjects == null || dataPersistanceObjects.Count == 0)
        {
            Debug.LogWarning("No data persistence objects found.");
            return;
        }

        // Check if gameData is null
        if (gameData == null)
        {
            Debug.LogWarning("GameData is null. Cannot save.");
            return;
        }

        // Pass the data to other scripts to update it
        foreach (IDataPresistance dataPersistenceObj in dataPersistanceObjects)
        {
            if (dataPersistenceObj != null)
            {
                dataPersistenceObj.SaveData(ref gameData);
            }
            else
            {
                Debug.LogWarning("One of the data persistence objects is null.");
            }
        }

        // Save the data to a file using the data handler
        if (dataHandler != null)
        {
            dataHandler.Save(gameData);
        }
        else
        {
            Debug.LogWarning("Data handler is null. Cannot save.");
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnApplicationFocus() => SaveGame();

    private List<IDataPresistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPresistance> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPresistance>();

        return new List<IDataPresistance>(dataPersistenceObjects);
    }

}
