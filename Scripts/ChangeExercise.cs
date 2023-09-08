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

    private int _currentTrainingNumber = 0;

    private void Awake()
    {
        Replace();
    }
    public void NextExercise()
    {
        if (_currentTrainingNumber < _training.Exercise.Count - 1)
        {
            _currentTrainingNumber++;
            Replace();
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
    private void Replace()
    {
        _changeExerciseUI.ReplaceExercise(_training.Exercise[_currentTrainingNumber]);
    }
}