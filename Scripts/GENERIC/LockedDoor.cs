using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private SOItem doorKey;

    [SerializeField] private GameObject lockedDoor;
    [SerializeField] private Material fadeOutMaterial;

    public float openWaitTime;

    public bool isOpened;

    public void Interact()
    {
        InventoryHandler inventory = FindObjectOfType<InventoryHandler>();

        if (inventory.ContainsItem(doorKey))
        {
            isOpened = true;
            openWaitTime = Time.time + openWaitTime;
            AudioManager.instance.PlaySfx(AudioManager.instance.unlockedDoorClip);
            inventory.RemoveItem(doorKey);

            lockedDoor.GetComponent<Renderer>().material = fadeOutMaterial;
        }
    }

    private void Update()
    {
        WaitBeforeDestroying();
    }

    private void WaitBeforeDestroying()
    {   
        if (isOpened)
        {
            if (Time.time > openWaitTime)
            {
                Destroy(lockedDoor);
            }
        }
    }
}
