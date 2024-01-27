using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int time = 0;
    public bool gameover;
    public float dificultad = 1;
    //Gestión viralidad
    public float viralidad = 95; // con la que se empieza, la podemos cambiar
    public float viralMax = 100; // La máxima, el tope
    public float viralLosing = 10; // limite a partir del cual estás a punto de morirte
    public float viralBurning = 80; // Limite a partir del cual te quemas

    [SerializeField] int tiempo_burning = 5;
    bool burning = false;
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
        if (viralidad == 0) 
        {
            SceneManager.LoadScene("4.2-Olvido");
        }
        if (viralidad >= viralBurning) 
        {
            burning = true;
        }
        //Si se pasa mucho tiempo en la viralidad muy alta se tiene que quemar

    }

    IEnumerator Burning()
    {
        while(tiempo_burning >= 0 && burning == true)
        {
            tiempo_burning--;
            yield return new WaitForSeconds(1);
            if (tiempo_burning == 0)
            {
                SceneManager.LoadScene("4.1-Burnt");
            }
        }
    }

    IEnumerator Contador()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
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
    //Manejo de escenas

    public void Inicio_Selector()
    {
        SceneManager.LoadScene("2-Selector");
    }
    public void Instrucciones_Game()
    {
        SceneManager.LoadScene("4-Game");
    }
    
    public void Replay()
    {
        SceneManager.LoadScene("1-Inicio");
    }
}