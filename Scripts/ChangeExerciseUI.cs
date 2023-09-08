using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class ChangeExerciseUI : MonoBehaviour
{
    [SerializeField] private Exercise _exercise;
    [Header("Video")]
    [SerializeField] private VideoPlayer _exerciseClip;
    [Header("Info")]
    [SerializeField] private TextMeshProUGUI _exerciseTitle;
    [SerializeField] private GameObject _useWeight;

    private void Awake()
    {
        AddInfoToUI();
    }
    private void AddInfoToUI()
    {
        _exerciseClip.clip = _exercise.ExerciseClip;
        _exerciseTitle.text = _exercise.ExerciseTitle;
        _useWeight.SetActive(_exercise.UseWeight);
    }
    public void ReplaceExercise(Exercise newExercise)
    {
        _exercise = newExercise;
        AddInfoToUI();
    }
}
