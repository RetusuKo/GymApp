using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTraining : MonoBehaviour
{
    public void LoadTraining(Training training)
    {
        Info.Training = training;
        print("Training change");
    }
}