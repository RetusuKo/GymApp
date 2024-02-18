using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLoad : MonoBehaviour, ILoadDataPersistence
{
    [SerializeField] private TextMeshProUGUI _timeAtGym;
    [SerializeField] private TextMeshProUGUI _timeAtHome;
    public void LoadData(Data data)
    {
        _timeAtGym.text = data.TimeInMinutes.ToString();
        _timeAtHome.text = data.TimeInMinutesHome.ToString();
    }
}
