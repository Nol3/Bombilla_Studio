using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] float aumento = 10;
    public bool available = true;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //para comprobar si las terminales est�n desactivadas
        if (available == false)
        {
            spriteRenderer.color = Color.red;
        } else if (available == true) 
        {
            spriteRenderer.color = Color.green;
        }
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && available == true)
        {
            GameManager.Instance.viralidad += aumento;
            GameManager.Instance.ResetTerminals();
            available = false;
        }
    }
}

