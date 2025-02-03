using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] public GameObject bubblePrefab;

    [SerializeField] public Vector3 bubbleSpawnPos;

    private void Start()
    {
        bubbleSpawnPos = transform.position;
    }
}
