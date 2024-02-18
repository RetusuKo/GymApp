using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calendar : MonoBehaviour, ILoadDataPersistence
{
    [SerializeField] private Transform[] _weeks;
    [SerializeField] private TextMeshProUGUI _yearAndMonth;

    private List<Day> _days = new List<Day>();
    private List<DateTime> _workoutDays = new List<DateTime>();
    private DateTime _currentDate = DateTime.Now;

    public void Start()
    {
        DataPersistenceManager.Instance.LoadData();
        UpdateCalendar(DateTime.Now.Year, DateTime.Now.Month);
    }
    private void UpdateCalendar(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);
        _currentDate = temp;
        _yearAndMonth.text = $"{temp.ToString("MMMM")} " +
            $"{temp.Year}";

        int startDay = GetMonthStartDay(year, month) - 1;
        int endDay = GetMonthEndDay(year, month);

        UpdateDays(startDay, endDay);
        HighlightTrainingDays(startDay, endDay);
        HighlightCurrentDay(startDay);
    }

    private void UpdateDays(int startDay, int endDay)
    {
        _days.Clear();

        for (int w = 0; w < 6; w++)
        {
            for (int d = 0; d < 7; d++)
            {
                int currentDay = (w * 7) + d;
                Day newDay = CreateDay(currentDay, startDay, endDay);
                _days.Add(newDay);
            }
        }
        print(_days.Count);
    }
    private Day CreateDay(int currentDay, int startDay, int endDay)
    {
        Day newDay;
        if (currentDay < startDay || currentDay - startDay >= endDay)
            newDay = new Day(currentDay - startDay, Color.gray, _weeks[currentDay / 7].GetChild(currentDay % 7).gameObject);
        else
        {
            newDay = new Day(currentDay - startDay, Color.white, _weeks[currentDay / 7].GetChild(currentDay % 7).gameObject);
        }
        return newDay;
    }

    private void HighlightCurrentDay(int startDay)
    {
        if (DateTime.Now.Year == _currentDate.Year && DateTime.Now.Month == _currentDate.Month)
            UpdateColorForDay((DateTime.Now.Day - 1) + startDay, Color.green);
    }
    private void HighlightTrainingDays(int startDay, int endDay)
    {
        print("_workoutDays.Count" + _workoutDays.Count);
        for (int i = startDay; i < startDay + endDay; i++)
        {
            DateTime currentDate = new DateTime(_currentDate.Year, _currentDate.Month, i - startDay + 1);

            if (_workoutDays.Contains(currentDate))
            {
                UpdateColorForDay(i, new Color(0, 255, 255));
            }
        }
    }
    private int GetMonthStartDay(int year, int month) => (int)new DateTime(year, month, 1).DayOfWeek;

    private int GetMonthEndDay(int year, int month) => DateTime.DaysInMonth(year, month);

    public void SwitchMonthForward(bool goToNextMonth)
    {
        if (goToNextMonth)
            _currentDate = _currentDate.AddMonths(1);
        else
            _currentDate = _currentDate.AddMonths(-1);
        DataPersistenceManager.Instance.LoadData();
        UpdateCalendar(_currentDate.Year, _currentDate.Month);
    }
    private void UpdateColorForDay(int day, Color color)
    {
        _days[day].UpdateColor(color);
    }
    public void LoadData(Data data)
    {
        for (int i = 0; i < data.WorkoutDate.Count; i++)
        {
            string key = data.WorkoutDate[i];
            string[] keyParts = key.Split('/');
            if (keyParts.Length == 4)
            {
                int day = int.Parse(keyParts[1]);
                int month = int.Parse(keyParts[2]);
                int year = int.Parse(keyParts[3]);

                DateTime currentDate = new DateTime(year, month, day);

                if (!_workoutDays.Contains(currentDate))
                {
                    //int value = data.WorkOutWeightWithDate.Values[i];
                    _workoutDays.Add(currentDate);
                }
            }
        }
    }
}