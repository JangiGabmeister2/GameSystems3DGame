using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardsMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 target;

    private void Start()
    {
        target = transform.position + new Vector3(0, 0, 70);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
}
