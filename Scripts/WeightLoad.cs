using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightLoad : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _workoutCount;
    [SerializeField] private TextMeshProUGUI _workoutCountAtHome;
    public void Initialize()
    {
        LoadExercise();
    }
    public void LoadExercise()
    {
        _workoutCount.text = PlayerPrefs.GetInt("WorkoutCount").ToString();
        _workoutCountAtHome.text = PlayerPrefs.GetInt("WorkoutCountHome").ToString();
    }
}
