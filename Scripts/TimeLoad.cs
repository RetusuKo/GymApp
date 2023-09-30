using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLoad : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _time;
    public void Initialize()
    {
        LoadExercise();
    }
    public void LoadExercise()
    {
        _time.text = PlayerPrefs.GetInt("TimeInMinutes").ToString();
    }
}
