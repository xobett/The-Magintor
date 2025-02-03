using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushTeleport_SCRPT : MonoBehaviour
{
    void Update()
    {
        ReturnToPlayerPostTp();
    }

    private void ReturnToPlayerPostTp()
    {
        if (PlayerIsTeleporting())
        {
            Destroy(this.gameObject);

            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInstanceBrush_SCRPT>().brushThrew = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera_SCRPT>().returnCameraToPlayer = true;

        }
    }
    private bool PlayerIsTeleporting()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTeleport_SCRPT>().playerIsTeleporting;
    }
}
