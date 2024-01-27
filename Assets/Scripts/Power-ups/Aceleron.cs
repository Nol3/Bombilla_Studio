using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aceleron : MonoBehaviour
{
    [SerializeField] float aumento_speed = 10f;
    [SerializeField] int tiempo_aceleron = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                player.aceleron = true;
            }
            Destroy(gameObject);
        }
    }
}
