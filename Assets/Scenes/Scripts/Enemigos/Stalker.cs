using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    [SerializeField] int salud = 1;
    [SerializeField] float speed = 1;
    Transform player;

    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawners");
        int random = Random.Range(0, spawns.Length);
        transform.position = spawns[random].transform.position;
    }

    void Update()
    {
        Vector2 direccion = player.position - transform.position;
        transform.position += (Vector3)direccion.normalized * Time.deltaTime * speed;

        if (salud <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<Player>().TakeDamage();
        }
    }
    public void TakeDamage()
    {
        salud--;
    }
}
