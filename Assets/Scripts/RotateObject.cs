using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    private Rigidbody rotateBody;
    private Vector3 EulerAngleVelocity;

    void Start()
    {
        EulerAngleVelocity = new Vector3(0, 80, 0);
        rotateBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.deltaTime);
        rotateBody.MoveRotation(rotateBody.rotation * deltaRotation);
    }
}