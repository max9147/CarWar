using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnemy : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f);

        if (transform.position.z > 100)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -20);
        }
    }
}