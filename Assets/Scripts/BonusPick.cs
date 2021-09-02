using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPick : MonoBehaviour
{
    public GameObject spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AmmoBonus"))
        {
            spawner.GetComponent<BonusSpawner>().canSpawn = true;
            GetComponent<Shooting>().BonusAmmo();
            spawner.GetComponent<BonusSpawner>().AmmoSound();
            Destroy(other.gameObject);
        }
    }
}