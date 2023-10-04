using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInfo : MonoBehaviour
{
    [SerializeField] private Bootstrap _bootstrap;
    private void Minutes_Changed(string minutes)
    {
        var min = int.Parse(minutes);
        PlayerPrefs.SetInt("TimeInMinutes", PlayerPrefs.GetInt("TimeInMinutes") + min);
        _bootstrap.Load();
    }
    private void MinutesHome_Changed(string minutes)
    {
        var min = int.Parse(minutes);
        PlayerPrefs.SetInt("TimeInMinutesHome", PlayerPrefs.GetInt("TimeInMinutesHome") + min);
        _bootstrap.Load();
    }
    private void AddWorkouts_Changed(string workouts)
    {
        var work = int.Parse(workouts);
        PlayerPrefs.SetInt("WorkoutCount", PlayerPrefs.GetInt("WorkoutCount") + work);
        _bootstrap.Load();
    }
    private void AddWorkoutsHome_Changed(string workouts)
    {
        var work = int.Parse(workouts);
        PlayerPrefs.SetInt("WorkoutCountHome", PlayerPrefs.GetInt("WorkoutCountHome") + work);
        _bootstrap.Load();
    }
}