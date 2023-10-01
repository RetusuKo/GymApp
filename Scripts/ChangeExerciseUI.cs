using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChangeExerciseUI : MonoBehaviour
{
    [SerializeField] private Exercise _exercise;
    [Header("Video")]
    [SerializeField] private VideoPlayer _exerciseClip;
    [Header("Info")]
    [SerializeField] private TextMeshProUGUI _exerciseTitle;
    [SerializeField] private List<GameObject> _useWeightObjects= new List<GameObject>();

    private void Awake()
    {
        AddInfoToUI();
    }
    private void AddInfoToUI()
    {
        _exerciseClip.clip = _exercise.ExerciseClip;
        _exerciseTitle.text = _exercise.ExerciseTitle;
        if (_exercise.UseWeight)
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
        PlayerPrefs.SetInt("WorkoutCount", PlayerPrefs.GetInt("WorkoutCount") + 1);
        SceneManager.LoadScene(0);
    }
}
