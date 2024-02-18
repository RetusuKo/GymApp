using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChangeExerciseUI : MonoBehaviour, ISaveDataPersistence, ILoadDataPersistence
{
    [SerializeField] private ChangeExercise _changeExercise;
    [SerializeField] private Exercise _exercise;
    [Header("Video")]
    [SerializeField] private VideoPlayer _exerciseClip;
    [Header("Info")]
    [SerializeField] private TextMeshProUGUI _exerciseTitle;
    [SerializeField] private TextMeshProUGUI _trainingName;
    [SerializeField] private List<GameObject> _useWeightObjects = new List<GameObject>();

    private int _workoutCountHome;
    private int _workoutCount;
    private void Start()
    {
        AddInfoToUI();
    }
    private void AddInfoToUI()
    {
        _exerciseClip.clip = _exercise.ExerciseClip;
        _exerciseTitle.text = _exercise.ExerciseTitle;
        _trainingName.text = _changeExercise.Training.TrainingName;
        for (int i = 0; i < _useWeightObjects.Count; i++)
            _useWeightObjects[i].SetActive(_exercise.UseWeight);
        _exerciseClip.Pause();
    }
    public void ReplaceExercise(Exercise newExercise, bool lastExercise = false)
    {
        if (!lastExercise)
        {
            _exercise = newExercise;
            AddInfoToUI();
        }
        else
        {
            EndTraining();
        }
    }
    private void EndTraining()
    {
        if (_exercise.FocusArea[0] == FocusAreaEnum.ABS)
            _workoutCountHome++;
        else
            _workoutCount++;
        DataPersistenceManager.Instance.SaveData();
        SceneManager.LoadScene(0);
    }

    public void SaveData(Data data)
    {
        data.WorkoutCountHome = _workoutCountHome;
        data.WorkoutCount = _workoutCount;
        print("ChangeExerciseUI data.WorkoutCount  " + data.WorkoutCount);
    }

    public void LoadData(Data data)
    {
        _workoutCountHome = data.WorkoutCountHome;
        _workoutCount = data.WorkoutCount;
    }
}