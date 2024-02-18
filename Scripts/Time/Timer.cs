using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour, ISaveDataPersistence, ILoadDataPersistence
{
    [SerializeField] private TextMeshProUGUI _timeTrainingUI;
    private float _elapsedTime = 1;
    private bool _canSave = true;
    private Exercise _exercise;

    private int _timeInMinutes;
    private int _timeInMinutesHome;

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
        StartCoroutine(WaitSec());
        if (_exercise.FocusArea[0] == FocusAreaEnum.ABS)
            _timeInMinutesHome++;
        else
            _timeInMinutes++;
        DataPersistenceManager.Instance.SaveData();
    }
    public void ReplaceExercise(Exercise newExercise, bool lastExercise = false)
    {
        if (!lastExercise)
            _exercise = newExercise;
    }

    public IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(1);
        _canSave = true;
    }

    public void SaveData(Data data)
    {
        data.TimeInMinutes = _timeInMinutes;
        data.TimeInMinutesHome = _timeInMinutesHome;
    }

    public void LoadData(Data data)
    {
        _timeInMinutes = data.TimeInMinutes;
        _timeInMinutesHome = data.TimeInMinutesHome;
    }
}