using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OnlineVideoLoader : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    private string _videoUrlStart = "https://numberoneiam.github.io/VideoGymApp/";

    public string VideoUrlExerciseName = "";

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
    }
    public void ChangeUrl()
    {
        try
        {
            _videoPlayer.url = _videoUrlStart + VideoUrlExerciseName + ".mp4";
            _videoPlayer.Prepare();
        }
        catch (Exception ex)
        {
            Debug.LogError("Error setting video URL: " + ex.Message);
        }
    }
}