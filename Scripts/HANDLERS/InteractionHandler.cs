using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private float interactionRange;

    public LayerMask interactionLayer;

    private RaycastHit hit;

    void Update()
    {
        if (IsCenteringObject() && IsInteracting() && !MenuPaused())
        {
            hit.collider.gameObject.GetComponent<IInteractable>().Interact();
        }

    }

    private bool MenuPaused()
    {
        return GameObject.FindObjectOfType<PauseMenu>().pausedMenu;
    }

    private bool IsCenteringObject()
    {
        return Physics.Raycast(transform.position, transform.forward * interactionRange, out hit, interactionRange, interactionLayer);

    }

    private bool IsInteracting()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
