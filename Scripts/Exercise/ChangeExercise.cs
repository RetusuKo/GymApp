using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class ChangeExercise : MonoBehaviour, ISaveDataPersistence
{
    [SerializeField] private Training _training;
    [SerializeField] private ChangeExerciseUI _changeExerciseUI;
    [SerializeField] private Timer _timer;
    [SerializeField] private ExerciseManager _weightSave;

    public Training Training { get { return _training; } }

    private int _currentTrainingNumber = 0;

    private void Awake()
    {
        _training = Info.Training;
        Replace();
    }
    public void NextExercise()
    {
        if (_currentTrainingNumber < _training.Exercise.Count - 1)
        {
            _currentTrainingNumber++;
            Replace();
        }
        else if (_currentTrainingNumber == _training.Exercise.Count - 1)
        {
            Replace(true);
        }
    }
    public void PreviousExercise()
    {
        if (_currentTrainingNumber > 0)
        {
            _currentTrainingNumber--;
            Replace();
        }
    }
    private void Replace(bool lastExercise = false)
    {
        _changeExerciseUI.ReplaceExercise(_training.Exercise[_currentTrainingNumber], lastExercise);
        _timer.ReplaceExercise(_training.Exercise[_currentTrainingNumber], lastExercise);
        if(lastExercise)
        {
            _saveInfo = true;
            DataPersistenceManager.Instance.SaveData();
        }
        DataPersistenceManager.Instance.LoadData();
    }
    private bool _saveInfo = false;
    public void SaveData(Data data)
    {
        if(_saveInfo)
        {
            string addInfo = $"{_training.TrainingName}/{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
            data.WorkoutDate.Add(addInfo);
            print(addInfo);
            _saveInfo = false;
        }
    }
}