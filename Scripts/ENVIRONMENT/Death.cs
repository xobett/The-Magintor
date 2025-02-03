using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Death : MonoBehaviour
{
    [SerializeField] private SOItem magicBrushItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySfx(AudioManager.instance.playerDeathClip);

            GameObject player = other.gameObject;

            player.GetComponent<CharacterController>().enabled = false;

            Vector3 offset = new Vector3(0, 1, 0);

            player.transform.position = player.GetComponent<PlayerCheckpoint>().lastCheckpoint.position + offset;
            player.transform.rotation = player.GetComponent<PlayerCheckpoint>().lastCheckpoint.rotation;

            player.GetComponent<CharacterController>().enabled = true;
        }
        else if (other.CompareTag("Decorative Brush") || other.CompareTag("Moving Brush"))
        {
            Destroy(other.gameObject);

            GameObject playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

            playerCamera.GetComponent<PlayerCamera_SCRPT>().returnCameraToPlayer = true;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInstanceBrush_SCRPT>().brushThrew = false;

            StartCoroutine(AddBrushPostDeath());
        }
    }

    private IEnumerator AddBrushPostDeath()
    {
        Transform cameraPos  = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Transform cameraDefaultPos = GameObject.FindGameObjectWithTag("Camera Default Position").transform;
        yield return new WaitUntil(() => Vector3.Distance(cameraPos.position, cameraDefaultPos.position) < 0.2f);

        InventoryHandler inventory = FindObjectOfType<InventoryHandler>();
        inventory.AddItem(magicBrushItem);

        yield return null;
    }
}
