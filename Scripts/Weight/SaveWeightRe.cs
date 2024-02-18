using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SaveWeightRe : MonoBehaviour, ISaveDataPersistence
{
    [SerializeField] private TextMeshProUGUI _exerciseName;

    [SerializeField] private int _number;

    private int _value;
    private string _currentKey;

    private string _currentType;
    private void Save(string dataType)
    {
        _currentKey = $"{dataType}{_exerciseName.text}{_number}";
        _currentType = dataType;
        DataPersistenceManager.Instance.SaveData();
    }
    public void TextWeight_Changed(string newText)
    {
        if (int.TryParse(newText, out _value))
            Save("Weight");
    }
    public void TextRepetition_Changed(string newText)
    {
        if (int.TryParse(newText, out _value))
            Save("Repeti");
    }

    public void SaveData(Data data)
    {
        if (_currentType == "Weight")
        {
            UpdateDictionary(data.WorkOutWeight, _currentKey + "", _value);
            //UpdateDictionary(data.WorkOutWeightWithDate, _currentKey + $" /{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}", _value);
        }
        else if (_currentType == "Repeti")
        {
            UpdateDictionary(data.WorkOutRepetitions, _currentKey, _value);
            //UpdateDictionary(data.WorkOutRepetitionsWithDate, _currentKey + $" /{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}", _value);
        }
    }
    private void UpdateDictionary(Dictionary<string, int> dictionary, string key, int value)
    {
        if (dictionary.ContainsKey(key))
            dictionary[key] = value;
        else
            dictionary.Add(key, value);
    }
}