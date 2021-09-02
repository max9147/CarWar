using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementSuicide : MonoBehaviour
{
    public ParticleSystem deathPS;
    public GameObject player;

    private NavMeshAgent agent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy") || collision.transform.CompareTag("Bullet") || collision.transform.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            deathPS.Play();
            Destroy(gameObject, 0.2f);
        }
    }
}