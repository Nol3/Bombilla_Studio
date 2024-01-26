using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [Range(1, 10)][SerializeField] float ratio = 1;

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / ratio);
            Instantiate(enemyPrefab);
        }
    }

}


