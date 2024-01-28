using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoStart : MonoBehaviour
{
    public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
    public GameObject StartBut, ExitBut;
    void Start()
    {
        VideoPlayer.loopPointReached += StartMenu; ;
    }
    void StartMenu(VideoPlayer vp)
    {
        StartBut.SetActive(true);
        ExitBut.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

