using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExerciseManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _exerciseName;
    [SerializeField] private List<TextMeshProUGUI> _weight = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> _repetitions = new List<TextMeshProUGUI>();

    private void Start()
    {
        Load();
    }
    private void SaveWeight(int valueWeight)
    {
        for (int i = 0; i < _weight.Count; i++)
            PlayerPrefs.SetInt(_exerciseName.text + "Weight" + i, valueWeight);
    }
    private void SaveRepetition(int valueRepetition)
    {
        for (int i = 0; i < _repetitions.Count; i++)
            PlayerPrefs.SetInt(_exerciseName.text + "Repetitions" + i, valueRepetition);
    }
    public void Load()
    {
        for (int i = 0; i < _weight.Count; i++)
        {
            _weight[i].text = PlayerPrefs.GetInt(_exerciseName.text + "Weight" + i).ToString();
            _repetitions[i].text = PlayerPrefs.GetInt(_exerciseName.text + "Repetitions" + i).ToString();
            print(_weight[i].text);
        }
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