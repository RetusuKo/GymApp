using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "New Training", menuName = "Training")]
public class Training : ScriptableObject
{
    [SerializeField] private List<Exercise> _exercise;
    [SerializeField] private string _name;

    public List<Exercise> Exercise { get { return _exercise; } }

    public string TrainingName { get { return _name; } }
}