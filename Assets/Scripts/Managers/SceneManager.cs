using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de tener esta línea

public class MySceneManager : MonoBehaviour
{
    //Manejo de escenas

    public void Inicio_Selector()
    {
        SceneManager.LoadScene("2-Selector");
    }

    public void Selector_Instrucciones()
    {
        SceneManager.LoadScene("3-Instrucciones");
    }

    public void Replay()
    {
        SceneManager.LoadScene("1-Inicio");
    }
}