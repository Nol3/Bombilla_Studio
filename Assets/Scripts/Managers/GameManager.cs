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

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
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
    /*public void JuagarOtra()
    {
        SceneManager.LoadScene("Game");
    }
    */
}