using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    [SerializeField] float aumento = 10;
    public bool available = true;
    [SerializeField] Transform Enemigo_terminal;
    [SerializeField] Sprite apagada;
    [SerializeField] Sprite encendida;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = encendida;
    }

    void Update()
    {
        //para comprobar si las terminales están desactivadas
        if (available == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = apagada;
        }
        else if (available == true) 
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = encendida;
        }
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && available == true)
        {
            GameManager.Instance.viralidad += aumento;
            //GameManager.Instance.ResetTerminals();
            available = false;
        } 
        if (collision.CompareTag("enemigo") && available == true)
        {
            //GameManager.Instance.ResetTerminals();
            available = false;
            StartCoroutine(WaitAndSetAvailable(5f));
        }
    }

    private IEnumerator WaitAndSetAvailable(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(FindFirstObjectByType<Enemigo_terminal>());
    }
}

