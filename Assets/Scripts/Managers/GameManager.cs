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
    //Gesti�n viralidad
    public float viralidad = 95; // con la que se empieza, la podemos cambiar
    public float viralMax = 100; // La m�xima, el tope
    public float viralLosing = 10; // limite a partir del cual est�s a punto de morirte
    public float viralBurning = 80; // Limite a partir del cual te quemas
    //Terminales
    GameObject[] arrayTerminal;

    //Caida viralidad
    float frecuencia = 0.1f; //cada cuantos segundos va a perder viralidad "disminucion"
    float disminucion = 1;   // cuanto cae la viralidad cada "frecuencia" segundos

    //Velocidad enemiga
    public bool realentizar = false;
    public float enemy_speed = 1;
    [SerializeField] int time_realentizar = 5;

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
    void Update ()
    {
        if (realentizar == true)
        {
            realentizar = false;
            StartCoroutine(Realentizar_enemigos());
        }
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

    IEnumerator Realentizar_enemigos()
    {
        float original = enemy_speed;
        enemy_speed = 0.2f;
        yield return new WaitForSeconds(time_realentizar);
        enemy_speed = original;
    }
    /*public void JuagarOtra()
    {
        SceneManager.LoadScene("Game");
    }
    */
}