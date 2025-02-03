using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstanceBrush_SCRPT : MonoBehaviour
{
    [SerializeField] private GameObject magicBrush;

    [SerializeField] private SOItem magicBrushItem;

    public bool brushThrew;

    private InventoryHandler inventory;

    private void Start()
    {
        inventory = gameObject.GetComponentInParent<InventoryHandler>();    
    }

    void Update()
    {
        ThrowBrush();
    }

    private void ThrowBrush()
    {
        if (IsThrowing() && HasBrush() && !CamIsNotReturning() && !MenuPaused())
        {
            AudioManager.instance.PlaySfx(AudioManager.instance.throwBrushClip);

            GameObject brushClone = Instantiate(magicBrush, transform.position, transform.rotation);
            brushThrew = true;

            inventory.RemoveItem(magicBrushItem);
            inventory.equippedObject = null;
        }
        else
        {
            return;
        }
    }

    private bool MenuPaused()
    {
        return GameObject.FindObjectOfType<PauseMenu>().pausedMenu;
    }

    private bool HasBrush()
    {
        return inventory.ContainsItem(magicBrushItem);    
    }

    private bool IsThrowing()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }

    private bool CamIsNotReturning()
    {
        return GameObject.FindObjectOfType<PlayerCamera_SCRPT>().returnCameraToPlayer;
    }
}
