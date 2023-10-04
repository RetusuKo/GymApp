using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeTrainingUI;
    private float _elapsedTime = 0;
    private bool _canSave = true;
    private Exercise _exercise;

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
        string timeKey = _exercise.FocusArea[0] == FocusAreaEnum.ABS ? "TimeInMinutesHome" : "TimeInMinutes";
        int current = PlayerPrefs.GetInt(timeKey, 0);
        current++;
        PlayerPrefs.SetInt(timeKey, current);
        print("save");
    }
    public void ReplaceExercise(Exercise newExercise, bool lastExercise = false)
    {
        if (!lastExercise)
        {
            _exercise = newExercise;
        }
    }

    public IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(1);
        _canSave = true;
    }
}
