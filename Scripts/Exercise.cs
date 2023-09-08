using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "New Exercise", menuName = "Exercise")]
public class Exercise : ScriptableObject
{
    [Header("Video")]
    [SerializeField] private VideoClip _exerciseClip;
    [Header("Info")]
    [SerializeField] private string _exerciseTitle;
    [SerializeField] private List<FocusAreaEnum> _focusArea = new List<FocusAreaEnum>();
    [SerializeField] private List<EquipmentEnum> _equipment = new List<EquipmentEnum>();
    [SerializeField] private bool _useWeight;

    public VideoClip ExerciseClip { get { return _exerciseClip; } }
    public string ExerciseTitle { get { return _exerciseTitle; } }
    public List<FocusAreaEnum> FocusArea { get { return _focusArea; } }
    public List<EquipmentEnum> Equipment { get { return _equipment; } }
    public bool UseWeight { get { return _useWeight; } }

}
public enum FocusAreaEnum
{
    Chest,
    Triceps,
    Back,
    Biceps,
    Legs,
    Shoulders
}
public enum EquipmentEnum
{
    test1,
    test2,
    test3
}