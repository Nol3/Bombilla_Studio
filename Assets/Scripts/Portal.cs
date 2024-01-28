using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GuardarVariables();
            GameManager.Instance.ResetTerminals();
            SceneManager.LoadScene("4.1-Zona1");
        }
    }

    void GuardarVariables()         //hay que guardar tambien time, y dificultad
    {
        PlayerPrefs.SetFloat("viralidad", GameManager.Instance.viralidad);
        PlayerPrefs.SetInt("time", GameManager.Instance.time);
        PlayerPrefs.SetFloat("dificultad", GameManager.Instance.dificultad);
        PlayerPrefs.Save();
    }
}
