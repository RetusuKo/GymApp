using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage  Config")]
    [SerializeField] private string _fileName;

    private Data _appData;

    private List<ILoadDataPersistence> _dataLoadPersistenceObjects;
    private List<ISaveDataPersistence> _dataSavePersistenceObjects;

    private FileDataHandler _dataHandler;
    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Found more than one Data Persistence manager in the scene. Destroy the newest one");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        _dataHandler = new FileDataHandler(Application.persistentDataPath, _fileName);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded  += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _dataLoadPersistenceObjects = FindAllLoadDataPersistenceObjects();
        _dataSavePersistenceObjects = FindAllSaveDataPersistenceObjects();
        LoadData();
    }
    public void OnSceneUnLoaded(Scene scene) 
    {
        SaveData();
    }

    public void NewData()
    {
        _appData = new Data();
    }
    public void LoadData()
    {
        _appData = _dataHandler.Load();

        if(_appData == null)
        {
            Debug.Log("No data was found.");
            NewData();
            return;
        }
        foreach (var item in _dataLoadPersistenceObjects)
        {
            item.LoadData(_appData);
        }
        print("Load DataPersistenceManager " + _appData.WorkoutCount);
    }
    public void SaveData()
    {
        foreach (var item in _dataSavePersistenceObjects)
            item.SaveData(_appData);
        print("Save DataPersistenceManager " + _appData.WorkoutCount);
        _dataHandler.Save(_appData);
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
    private List<ILoadDataPersistence> FindAllLoadDataPersistenceObjects()
    {
        IEnumerable<ILoadDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<ILoadDataPersistence>();
        return new List<ILoadDataPersistence>(dataPersistenceObjects);
    }
    private List<ISaveDataPersistence> FindAllSaveDataPersistenceObjects()
    {
        IEnumerable<ISaveDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<ISaveDataPersistence>();
        return new List<ISaveDataPersistence>(dataPersistenceObjects);
    }
}
