using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private AppData _appData;

    public static DataPersistenceManager Instance { get; private set;}

    private void Awake()
    {
        if(Instance  != null)
            Debug.LogError("Found more than ona  Data Persistence Manager in the scene");
        Instance = this;
    }
    private void Start()
    {
        LoadAppData();
    }

    public void NewAppData()
    {
        _appData = new AppData();
    }
    public void LoadAppData()
    {
        if(_appData == null)
        {
            Debug.Log("No data was found, Initializing data to defaults");
            NewAppData();
        }
    }
    public void SavaAppData()
    {
        
    }
    private void OnApplicationQuit()
    {
        SavaAppData();
    }
}
