using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ControllerMovement : MonoBehaviour
{
    public float speed = 5f;
    public CharacterController charC;

    private void Start()
    {
        charC = GetComponent<CharacterController>();
    }

    void Update()
    {
        charC.Move(Vector3.forward * speed * Time.deltaTime);
    }
}
