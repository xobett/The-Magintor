using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTest : MonoBehaviour
{
    public GameObject testCube; 

    void Update()
    {
        Vector3 relativePos = transform.position - testCube.transform.position;
        Quaternion lookatCube = Quaternion.LookRotation(relativePos);
        transform.rotation = lookatCube;
    }
}
