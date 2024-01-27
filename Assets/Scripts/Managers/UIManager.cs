using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image barra;
    private float viralActual;
    private float viralMax; // La máxima, el tope
    private float viralLosing; // limite a partir del cual estás a punto de morirte
    private float viralBurning; // Limite a partir del cual te quemas

    void Start() 
    {

    }

    void Update()
    {
        viralActual = GameManager.Instance.viralidad;
        viralMax = GameManager.Instance.viralMax;
        viralBurning = 90;//viralBurning = GameManager.Instance.viralBurning;
        viralLosing = 10; //viralLosing = GameManager.Instance.viralLosing;

        if (viralActual > viralMax)//Esto por si se pasa de viralidad máxima
            viralActual = viralMax;

        barra.fillAmount = viralActual/viralMax;// Llena la barra

        if (viralActual >= viralBurning)// cuando llega al limite alto se pone en rojo
        {
            barra.color = Color.red;
        } else if (viralActual <= viralLosing) // cuando llega al limite bajo se pone en rojo
        {
            barra.color = Color.red;
        }else
        {
            barra.color = Color.green;
        }
    }
}
