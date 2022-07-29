using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VelocityMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rB;

    private void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rB.velocity = Vector3.forward * speed;
    }
}
