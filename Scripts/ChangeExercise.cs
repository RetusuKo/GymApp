using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class ChangeExercise : MonoBehaviour
{
    [SerializeField] private Training _training;
    [SerializeField] private ChangeExerciseUI _changeExerciseUI;
    [SerializeField] private WeightSave _weightSave;


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
        _weightSave.LoadExercise();
    }
}