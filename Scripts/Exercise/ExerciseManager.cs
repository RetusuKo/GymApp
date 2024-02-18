using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ExerciseManager : MonoBehaviour, /*ISaveDataPersistence,*/ ILoadDataPersistence
{
    [SerializeField] private TextMeshProUGUI _exerciseName;
    [SerializeField] private List<TextMeshProUGUI> _weight = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> _repetitions = new List<TextMeshProUGUI>();
    [SerializeField] private bool _loadWithNoChangedDate = false;

    private int _value;
    private string _type;
    private void Start()
    {
        DataPersistenceManager.Instance.LoadData();
    }
    private void SaveWeight()
    {
        _type = "Weight" + _exerciseName.text + _value;
        DataPersistenceManager.Instance.LoadData();
    }
    private void SaveRepetition()
    {
        _type = "Repeti" + _exerciseName.text + _value;
        DataPersistenceManager.Instance.LoadData();
    }
    public void TextWeight_Changed(string newText)
    {
        _value = int.Parse(newText);
        SaveWeight();
    }
    public void TextRepetition_Changed(string newText)
    {
        _value = int.Parse(newText);
        SaveRepetition();
    }
    public void TextWeightWithDate_Changed(string newText)
    {
        _value = int.Parse(newText);
        SaveWeight();
    }
    public void TextRepetitionWithDate_Changed(string newText)
    {
        _value = int.Parse(newText);
        SaveRepetition();
    }

    public void LoadData(Data data)
    {
        for (int i = 0; i < _repetitions.Count; i++)
        {
            string weight;
            string reps;
            try
            {
                weight = data.WorkOutWeight["Weight" + _exerciseName.text + i].ToString();
                _weight[i].text = weight;
                if(_loadWithNoChangedDate)
                {

                }

            }
            catch
            {
                print("No info for ExerciseManager LoadData for Weight");
                _weight[i].text = "0";
            }
            try
            {
                reps = data.WorkOutRepetitions["Repeti" + _exerciseName.text + i].ToString();
                _repetitions[i].text = reps;
                if (_loadWithNoChangedDate)
                {

                }
            }
            catch
            {
                print("No info for ExerciseManager LoadData for Repetitions");
                _repetitions[i].text = "0";
            }
        }
    }
}