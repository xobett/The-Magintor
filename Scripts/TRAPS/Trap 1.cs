using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    [SerializeField] private float spinningSpeed;
    [SerializeField] private Vector3 rotationDirection;

    void Update()
    {
        TrapRotation();
    }

    private void TrapRotation()
    {
        rotationDirection = Vector3.up;
        transform.Rotate(spinningSpeed * rotationDirection * Time.deltaTime);
    }
}
