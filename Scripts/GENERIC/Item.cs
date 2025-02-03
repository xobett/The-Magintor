using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private SOItem item;

    private InventoryHandler inventory;

    private bool isTargeting;

    private void Start()
    {
        inventory = FindObjectOfType<InventoryHandler>();
    }

    public void Interact()
    {
        inventory.DropEquippedItem();
        inventory.AddItem(item);
        Destroy(this.gameObject);
    }
}
