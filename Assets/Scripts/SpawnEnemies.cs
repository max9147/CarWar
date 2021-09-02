using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemySuicide;

    private void Start()
    {
        InvokeRepeating("Spawn", 2f, 5f);
    }

    private void Spawn()
    {
        if (Random.Range(0,10)>0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemySuicide, transform.position, Quaternion.identity);
        }
    }
}