using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersietenceManager : MonoBehaviour
{
    [Tooltip("File that game save data will be stored in")]
    [SerializeField] string fileName;

    GameData gameData;
    List<DataPersistor> dataPersistorObjects;
    DataFileHandler dataHandler;

    public static DataPersietenceManager instance { get; private set; }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Additional data managers found in scene");
        }
        instance = this;
    }

    void Start()
    {
        this.dataHandler = new DataFileHandler(Application.persistentDataPath, fileName);
        this.dataPersistorObjects = FindAllDataPersistorObjects();
    }

    public void NewSave()
    {
        this.gameData = new GameData();
    }

    public void LoadSave()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No save data found. Starting new game");
            NewSave();
        }
        foreach (DataPersistor dataPersistor in dataPersistorObjects)
        {
            dataPersistor.LoadSave(gameData);
        }
    }

    public void WriteSave()
    {

    }

    List<DataPersistor> FindAllDataPersistorObjects()
    {
        IEnumerable<DataPersistor> dataPersistorObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<DataPersistor>();
        return new List<DataPersistor> (dataPersistorObjects);
    }
}
