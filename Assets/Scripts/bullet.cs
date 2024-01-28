using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemigo"))
        {
            if (collision.TryGetComponent<Enemigo_terminal>(out Enemigo_terminal enemigo))
            {
                enemigo.TakeDamage();
            }
            else if (collision.TryGetComponent<Stalker>(out Stalker seguidor))
            {
                seguidor.TakeDamage();
            }
            Destroy(gameObject);
        }
    }
}
