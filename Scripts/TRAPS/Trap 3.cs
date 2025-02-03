using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap3 : MonoBehaviour
{
    private Rigidbody trapRb;

    [SerializeField] private float rotateForce;

    [SerializeField] private Quaternion limitRotation;

    public bool shouldGoOtherWay;
    void Start()
    {
        trapRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Quaternion trapQuaternion = transform.rotation;

        if (trapQuaternion.z >= limitRotation.z)
        {
            rotateForce = -rotateForce;
            shouldGoOtherWay = true;
            Debug.Log("Velocidad se hace negativa");
        }
        else if (trapQuaternion.z <= -limitRotation.z)
        {
            rotateForce *= -1;
            Debug.Log("Velocidad se invierte.");
        }

        Quaternion quaternion = Quaternion.Euler(Vector3.forward * rotateForce * Time.deltaTime);
        trapRb.MoveRotation(trapRb.rotation * quaternion);
    }

}
