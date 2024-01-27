using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RickTroll : MonoBehaviour
{
    [SerializeField] public GameObject rickTroll;
    [SerializeField] public GameObject rickTroll1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                StartCoroutine(ActivateAndDeactivate());
                Destroy(gameObject);
            }
            
        }
    }
    IEnumerator ActivateAndDeactivate()
    {
        rickTroll.SetActive(true);
        rickTroll1.SetActive(true);

        yield return new WaitForSeconds(5);

        rickTroll.SetActive(false);
        rickTroll1.SetActive(false);
    }
}
