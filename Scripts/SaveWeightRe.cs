using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SaveWeightRe : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _exerciseName;

    [SerializeField] private int _number;

    private void SaveWeight(int valueWeight)
    {
        PlayerPrefs.SetInt(_exerciseName.text + "Weight" + _number, valueWeight);
    }
    private void SaveRepetition(int valueRepetition)
    {
        PlayerPrefs.SetInt(_exerciseName.text + "Repetitions" + _number, valueRepetition);
    }
    public void TextWeight_Changed(string newText)
    {
        int value = int.Parse(newText);
        SaveWeight(value);
    }
    public void TextRepetition_Changed(string newText)
    {
        int value = int.Parse(newText);
        SaveRepetition(value);
    }
}