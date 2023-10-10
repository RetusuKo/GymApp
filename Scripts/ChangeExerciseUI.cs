using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChangeExerciseUI : MonoBehaviour
{
    [SerializeField] private Exercise _exercise;
    [Header("Video")]
    [SerializeField] private VideoPlayer _exerciseClip;
    [SerializeField] private OnlineVideoLoader _onlineVideoLoader;
    [Header("Info")]
    [SerializeField] private TextMeshProUGUI _exerciseTitle;
    [SerializeField] private List<GameObject> _useWeightObjects = new List<GameObject>();

    private void Start()
    {
        AddInfoToUI();
    }
    private void AddInfoToUI()
    {
        _onlineVideoLoader.VideoUrlExerciseName = _exercise.ExerciseTitle;
        _onlineVideoLoader.ChangeUrl();
        _exerciseTitle.text = _exercise.ExerciseTitle;
        for (int i = 0; i < _useWeightObjects.Count; i++)
            _useWeightObjects[i].SetActive(_exercise.UseWeight);
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
            PlayerPrefs.SetInt("WorkoutCountHome", PlayerPrefs.GetInt("WorkoutCountHome") + 1);
        else
            PlayerPrefs.SetInt("WorkoutCount", PlayerPrefs.GetInt("WorkoutCount") + 1);
        SceneManager.LoadScene(0);
    }
}