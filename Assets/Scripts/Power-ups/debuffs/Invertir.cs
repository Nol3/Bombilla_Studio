using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                player.invertido = true;
            }
            Destroy(gameObject);
        }
    }
}

