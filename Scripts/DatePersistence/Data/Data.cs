using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int TimeInMinutes;
    public int TimeInMinutesHome;
    public int WorkoutCount;
    public int WorkoutCountHome;

    public SerializableDictionary<string, int> WorkOutRepetitions;
    public SerializableDictionary<string, int> WorkOutWeight;

    //public SerializableDictionary<string, int> WorkOutRepetitionsWithDate;
    //public SerializableDictionary<string, int> WorkOutWeightWithDate;
    public List<string> WorkoutDate;
    public Data()
    {
        TimeInMinutes = 0;
        TimeInMinutesHome = 0;
        WorkoutCount = 0;
        WorkoutCountHome = 0;
        WorkOutRepetitions = new SerializableDictionary<string, int>();
        WorkOutWeight = new SerializableDictionary<string, int>();
    }
}
