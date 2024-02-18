using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightLoad : MonoBehaviour, ILoadDataPersistence
{
    [SerializeField] private TextMeshProUGUI _workoutAtGymCount;
    [SerializeField] private TextMeshProUGUI _workoutAtHomeCount;

    public void LoadData(Data data)
    {
        _workoutAtGymCount.text = data.WorkoutCount.ToString();
        _workoutAtHomeCount.text = data.WorkoutCountHome.ToString();
    }
}
