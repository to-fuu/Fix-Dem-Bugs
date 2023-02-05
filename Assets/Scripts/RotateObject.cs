using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    //HIGH QUALITY CODE UP AHEAD

    public float rotationSpeed = 180;

    void Update()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime);
    }
}
