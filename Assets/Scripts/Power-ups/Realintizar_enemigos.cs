using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realintizar_enemigos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                GameManager.Instance.realentizar = true;
            }
            Destroy(gameObject);
        }
    }
}
