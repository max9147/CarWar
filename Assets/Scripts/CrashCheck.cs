using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCheck : MonoBehaviour
{
    public GameObject player;

    private bool isDead = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isDead && !other.CompareTag("AmmoBonus"))
        {
            player.GetComponent<PlayerMovement>().Death();
            isDead = true;
        }
    }
}