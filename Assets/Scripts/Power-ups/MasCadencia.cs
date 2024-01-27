using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasCadencia : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                player.masCadencia = true;
                Destroy(gameObject);
            }
        }
    }
}
