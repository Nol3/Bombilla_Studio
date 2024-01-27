using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int time = 30;
    public bool gameover;
    public int dificultad = 1;
    public float viralidad = 50;
    //Terminales
    GameObject[] arrayTerminal;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        arrayTerminal = GameObject.FindGameObjectsWithTag("Terminal");
        StartCoroutine(Contador());
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
    /*public void JuagarOtra()
    {
        SceneManager.LoadScene("Game");
    }
    */
}