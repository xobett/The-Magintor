using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public List<SOItem> inventory =  new List<SOItem>();

    public SOItem equippedObject;

    [SerializeField] public Transform handPos;

    private GameObject displayedObject;

    private void Start()
    {
        equippedObject = null;
    }

    public bool ContainsItem(SOItem itemToVerify)
    {
        return inventory.Contains(itemToVerify);
    }

    public void RemoveItem(SOItem itemToRemove)
    {
        inventory.Remove(itemToRemove);
        equippedObject = null;
        Destroy(displayedObject);
    }

    public void AddItem(SOItem itemToAdd)
    {
        inventory.Add(itemToAdd);
        equippedObject = itemToAdd;
        PlaceItemInHand();

    }

    private void PlaceItemInHand()
    {
        displayedObject = Instantiate(equippedObject.itemPrefab, handPos.position, handPos.rotation);

        displayedObject.GetComponent<Rigidbody>().isKinematic = true;
        displayedObject.GetComponent<Collider>().enabled = false;
        displayedObject.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;

    }

    public void DropEquippedItem()
    {
        if (equippedObject != null)
        {
            //Deletes equipped item from inventory and from camera view
            Destroy(displayedObject);

            //Gets front item spawn position 
            Vector3 itemSpawnPos = transform.position + transform.forward * 1;

            //Drops item
            Instantiate(equippedObject.itemPrefab, itemSpawnPos, equippedObject.itemPrefab.transform.rotation);

            RemoveItem(equippedObject);
            equippedObject = null;
        }
        else
        {
            return;
        }
    }
}
