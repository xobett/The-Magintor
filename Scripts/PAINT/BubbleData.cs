using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleData : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab;

    [SerializeField] private Vector3 bubbleSpawnPos;

    private void Start()
    {
        bubbleSpawnPos = transform.position;
    }
}
