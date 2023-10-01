using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeTrainingUI;
    private float _elapsedTime = 0;
    private bool _canSave = true;
    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        UpdateTimeUI();
    }

    private void UpdateTimeUI()
    {
        if (Mathf.FloorToInt(_elapsedTime % 60) == 0 && _canSave == true)
            SaveExerciseAndResetTimer();
        int minutes = Mathf.FloorToInt(_elapsedTime / 60);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60);
        _timeTrainingUI.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
    private void SaveExerciseAndResetTimer()
    {
        _canSave = false;
        WaitSec();
        int current = PlayerPrefs.GetInt("TimeInMinutes", 0);
        current++;
        PlayerPrefs.SetInt("TimeInMinutes", current);
        print("save");
    }
    public IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(1);
        _canSave = true;
    }
    //[SerializeField] private TextMeshProUGUI _timeTrainingUI;
    //private int _minutes = 0;
    //private int _seconds = 60;
    //private float _timeLeft;

    //private void Start()
    //{
    //    _timeLeft = _seconds;
    //}
    //private void Update()
    //{
    //    if (_timeLeft > 0)
    //    {
    //        _timeLeft -= Time.deltaTime;
    //        UpdateTimeUI();
    //    }
    //    else
    //    {
    //        SaveExerciseAndResetTimer();
    //    }
    //}

    //private void SaveExerciseAndResetTimer()
    //{
    //    int current = PlayerPrefs.GetInt("TimeInMinutes", 0);
    //    current++;
    //    PlayerPrefs.SetInt("TimeInMinutes", current);
    //    ResetTimer();
    //}

    //private void ResetTimer()
    //{
    //    _minutes++;
    //    _seconds = 60;
    //    _timeLeft = _seconds;
    //    UpdateTimeUI();
    //}
    //private void UpdateTimeUI()
    //{
    //    int displayMinutes = Mathf.FloorToInt(_timeLeft / 60);
    //    int displaySeconds = Mathf.FloorToInt(_timeLeft % 60);
    //    _timeTrainingUI.text = string.Format("{0:D2}:{1:D2}", displayMinutes, displaySeconds);
    //}
}
