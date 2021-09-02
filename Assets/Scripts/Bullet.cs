using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 2f;

    private Vector3 target;

    public void GetDirection(Vector3 target)
    {
        this.target = target;
        this.target.y = 0;
    }

    private void FixedUpdate()
    {
        transform.position += target * bulletSpeed;
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Camera.main.GetComponent<CameraMovement>().AddScore();
        }
        if (collision.transform.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}