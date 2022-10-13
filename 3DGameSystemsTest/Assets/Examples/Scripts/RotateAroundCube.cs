using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCube : MonoBehaviour
{
    public GameObject centerCube;

    private void Update()
    {
        Orbit(centerCube);
    }

    private void Orbit(GameObject gameObject)
    {
        transform.RotateAround(gameObject.transform.position, Vector3.up, 50 * Time.deltaTime);
    }
}
