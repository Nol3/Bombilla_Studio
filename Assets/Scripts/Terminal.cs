using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] float aumento = 10;
    public bool available = true;
    SpriteRenderer spriteRenderer;
    [SerializeField] Transform Enemigo_terminal;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //para comprobar si las terminales están desactivadas
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

