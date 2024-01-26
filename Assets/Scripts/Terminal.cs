using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] float aumento = 10;
    public bool available = true;
    public GameManager gameManager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && available == true)
        {
            GameManager.Instance.viralidad += aumento;
            gameManager.ResetTerminals();
            available = false;
        }
    }
}
