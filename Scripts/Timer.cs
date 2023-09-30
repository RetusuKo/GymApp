using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeTrainingUI;
    private float _timeInMinutes = 0;
    private float _totalTime = 1;
    private float _timeLeft;

    private void Start()
    {
        _timeLeft = _totalTime;
    }
    private void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
        }
        else
        {
            SaveExerciseAndResetTimer();
        }
    }

    private void SaveExerciseAndResetTimer()
    {
        int current = PlayerPrefs.GetInt("TimeInMinutes", 0);
        current++;
        PlayerPrefs.SetInt("TimeInMinutes", current);
        ResetTimer();
    }

    private void ResetTimer()
    {
        _timeLeft = _totalTime;
        _timeInMinutes++;
        _timeTrainingUI.text = _timeInMinutes.ToString();
    }
}
