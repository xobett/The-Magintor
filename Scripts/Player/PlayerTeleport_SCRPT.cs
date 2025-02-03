using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport_SCRPT : MonoBehaviour
{
    private CharacterController playerCharCtrl;

    [Header("TELEPORT SETTINGS")]

    public bool playerIsTeleporting;

    [SerializeField] private float teleportCooldown =  2f;
    [SerializeField] private float nextTeleport = 0.0f;

    private InventoryHandler inventory;
    [SerializeField] private SOItem magicBrushItem;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        playerCharCtrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        TeleportToBrush();
    }

    private void TeleportToBrush()
    {
        if (BrushThrewCheck() && !MenuPaused())
        {
            if (IsTeleporting() && !playerIsTeleporting &&  Time.time > nextTeleport && !isColliding())
            {
                playerIsTeleporting = true;
                nextTeleport = Time.time + teleportCooldown;

                GameObject movingBrush = GameObject.FindGameObjectWithTag("Moving Brush");
                Vector3 posToTeleport = movingBrush.transform.position;
                Quaternion brushRotation = movingBrush.transform.rotation;

                Destroy(movingBrush);

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                GameObject playerCam = GameObject.FindGameObjectWithTag("MainCamera");

                playerCam.transform.parent = null;

                AudioManager.instance.PlaySfx(AudioManager.instance.teleportToBrushClip);

                //Player teleport (Character Controler must be disabled in order to do it)
                playerCharCtrl.enabled = false;
                transform.position = posToTeleport;
                transform.rotation = brushRotation;

                playerCharCtrl.enabled = true;

                playerCam.transform.parent = player.transform;

                //player.GetComponentInChildren<PlayerInstanceBrush_SCRPT>().brushThrew = false;
                playerCam.GetComponent<PlayerCamera_SCRPT>().returnCameraToPlayer = true;

                inventory = FindObjectOfType<InventoryHandler>();
                inventory.AddItem(magicBrushItem);
            }
        }
    }

    private bool isColliding()
    {
        return FindObjectOfType<BrushCollision>().brushCollided;
    }

    private bool MenuPaused()
    {
        return GameObject.FindObjectOfType<PauseMenu>().pausedMenu;
    }

    private bool BrushThrewCheck()
    {
        return gameObject.GetComponentInChildren<PlayerInstanceBrush_SCRPT>().brushThrew;
    }

    private bool IsTeleporting()
    {
        return Input.GetKeyDown(KeyCode.T);
    }
}
