using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FramerateChange : MonoBehaviour
{
    private void Start()
    {
        RequestFrameRateApp(50);
    }
    public void RequestFrameRateApp(int framerate)
    {
        Application.targetFrameRate = framerate;
    }
}
