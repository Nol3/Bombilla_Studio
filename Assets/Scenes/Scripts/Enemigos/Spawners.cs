using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Instantiate(enemyPrefab);
        }
    }

}


