using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightSave : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _exerciseName;
    [SerializeField] private TextMeshProUGUI _weight;

    private void Start()
    {
        LoadExercise();
    }
    private void SaveExercise(int value)
    {
        PlayerPrefs.SetInt(_exerciseName.text, value);
    }
    public void LoadExercise()
    {
        _weight.text = PlayerPrefs.GetInt(_exerciseName.text).ToString();
    }
    public void Text_Changed(string newText)
    {
        int value = int.Parse(newText);
        SaveExercise(value);
    }
}