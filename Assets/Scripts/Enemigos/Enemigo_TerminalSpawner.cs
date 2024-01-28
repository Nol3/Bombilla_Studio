using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_TerminalSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int tiempo = 3;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempo*(1/GameManager.Instance.dificultad));
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
