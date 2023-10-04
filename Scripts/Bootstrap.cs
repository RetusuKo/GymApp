using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private WeightLoad _weightLoad;
    [SerializeField] private TimeLoad _timeLoad;
    private void Awake()
    {
        Load();
    }
    public void Load()
    {
        _weightLoad.Initialize();
        _timeLoad.Initialize();
    }
}