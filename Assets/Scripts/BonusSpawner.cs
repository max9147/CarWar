using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject bonusAmmo;
    public GameObject[] spawnPoints;
    public bool canSpawn = true;

    private void Start()
    {
        InvokeRepeating("Spawn", 20f, 20f);
    }

    private void Spawn()
    {
        if (canSpawn)
        {
        canSpawn = false;
        int point = Random.Range(0, spawnPoints.Length);
        Instantiate(bonusAmmo, spawnPoints[point].transform.position, Quaternion.identity);
        }
    }

    public void AmmoSound()
    {
        GetComponent<AudioSource>().Play();
    }
}