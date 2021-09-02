using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Vector3[] targetPoints;
    public ParticleSystem deathPS;
    
    private NavMeshAgent agent;
    private int point;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        point = Random.Range(0, 8);
        agent.destination = targetPoints[point];
    }

    private void Update()
    {
        if (agent.remainingDistance < 10f)
        {
            point = Random.Range(0, 8);
            agent.destination = targetPoints[point];
        }
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