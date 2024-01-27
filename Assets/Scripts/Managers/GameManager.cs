using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int time = 30;
    public bool gameover;
    public float dificultad = 1;
    //Gestión viralidad
    public float viralidad = 95; // con la que se empieza, la podemos cambiar
    public float viralMax = 100; // La máxima, el tope
    public float viralLosing = 10; // limite a partir del cual estás a punto de morirte
    public float viralBurning = 80; // Limite a partir del cual te quemas
    //Terminales
    GameObject[] arrayTerminal;

    //Caida viralidad
    float frecuencia = 0.1f; //cada cuantos segundos va a perder viralidad "disminucion"
    float disminucion = 1;   // cuanto cae la viralidad cada "frecuencia" segundos

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //Mantener viralidad, tiempo y dificultad entre escenas
        viralidad = PlayerPrefs.GetFloat("viralidad", viralidad);
        dificultad = PlayerPrefs.GetFloat("dificultad", dificultad);
        time = PlayerPrefs.GetInt("time", time);
    }

    void Start()
    {
        arrayTerminal = GameObject.FindGameObjectsWithTag("Terminal");
        StartCoroutine(Contador());
        StartCoroutine(CaidaViralidad());
    }

    IEnumerator Contador()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
        if (time <= 0)
        {
            gameover = true;
           //IManager.Instance.GameOver();
        }
    }

    public void ResetTerminals() 
    {
        int i = arrayTerminal.Length - 1;
        while(i >= 0)
        {
           arrayTerminal[i].GetComponent<Terminal>().available = true;
            i--;
        }
    }

    IEnumerator CaidaViralidad() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(frecuencia);
            viralidad -= disminucion;
        }
    }
    /*public void JuagarOtra()
    {
        SceneManager.LoadScene("Game");
    }
    */
}