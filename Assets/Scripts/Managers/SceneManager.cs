using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
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

    public void Instrucciones_Game()
    {
        SceneManager.LoadScene("4-Game");
    }

    public void Replay()
    {
        SceneManager.LoadScene("1-Inicio");
    }

    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }

    internal static void LoadScene(int v)
    {
        throw new NotImplementedException();
    }
}
