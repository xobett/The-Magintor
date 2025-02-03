using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBubbleSpawner : MonoBehaviour
{
    [SerializeField] private float respawnWaitTime;

    public void RespawnPaintBubble(SOPaintBubble bubbleSO, Vector3 position, Quaternion rotation, float bubbleVelocity)
    {
        Vector3 spawnPos = position;

        Quaternion spawnRot = rotation;

        float bubbleSpeed = bubbleVelocity;

        StartCoroutine(WaitBeforeRespawn(bubbleSO, spawnPos, spawnRot, bubbleSpeed));
    }


    private IEnumerator WaitBeforeRespawn(SOPaintBubble bubbleSO, Vector3 spawnPosition, Quaternion spawnRotation, float bubbleVelocity)
    {
        yield return new WaitForSeconds(respawnWaitTime);

        GameObject bubbleInstantiated = Instantiate(bubbleSO.paintBubblePrefab, spawnPosition, spawnRotation);
        bubbleInstantiated.GetComponentInChildren<Movement>().speed = bubbleVelocity;

        yield return null;
    }

}
