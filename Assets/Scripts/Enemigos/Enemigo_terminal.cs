using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_terminal : MonoBehaviour
{
    [SerializeField]int salud = 1;
    Transform Terminal;
    bool available = false;
    SpriteRenderer spriteRenderer;
    [SerializeField]AudioClip impacto;
    Transform player;
    public float speed = 1f;
    //[SerializeField] float waitTime = 5.5f;

    void Start()
    {
        Terminal = GameObject.FindWithTag("Terminal").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //movimiento del enemigo
        //Vector2 direccion = Terminal.position - transform.position;
        //transform.position += (Vector3)direccion.normalized * Time.deltaTime * GameManager.Instance.enemy_speed;
        Vector2 direction = (Terminal.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, Terminal.position, speed * Time.deltaTime);


        //para comprobar si las terminales están desactivadas
        if (available == false)
        {
            spriteRenderer.color = Color.yellow;
        }
        else if (available == true)
        {
            spriteRenderer.color = Color.green;
        }
    }
    public void TakeDamage()
    {
        salud--;
        AudioSource.PlayClipAtPoint(impacto, transform.position);
        if (salud <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Terminal") && available == false)
        {
            GameManager.Instance.ResetTerminals();
            StartCoroutine(WaitAndSetAvailable(5f));
        }
    }

    private IEnumerator WaitAndSetAvailable(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        available = true;
        Destroy(gameObject);
    }
}
