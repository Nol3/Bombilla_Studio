using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTerminal : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool available = true;
    public float viralBurning;
    void Start()
    {
        viralBurning = GameManager.Instance.viralBurning;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (available == false)
        {
            spriteRenderer.color = Color.red;
        }
        else if (available == true)
        {
            spriteRenderer.color = Color.green;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && available == true)
        {
            GameManager.Instance.viralidad = viralBurning;
            available = false;
            //if cambio de escena available = true
        }
    }
}
