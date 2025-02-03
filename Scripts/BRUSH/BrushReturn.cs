using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushReturn : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float returnSpeed;

    [SerializeField] private SOItem visualBrush;

    private bool brushCalled;

    private Vector3 velocity = Vector3.zero;

    [SerializeField] private InventoryHandler inventory;

    public Vector3 spawnPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        inventory = GameObject.FindObjectOfType<InventoryHandler>();

        spawnPosition = transform.position;
    }

    void Update()
    {
        CallBrush();
        BrushMotion();
    }

    private void CallBrush()
    {
        if (inventory.equippedObject == null)
        {
            if (IsCallingBrush() && !BrushThrewCheck() && !inventory.ContainsItem(visualBrush) && !brushCalled)
            {
                brushCalled = true;
                StartCoroutine(WaitUntilBrushReturns());
            }
        }
    }

    private bool IsCallingBrush()
    {
        return Input.GetKeyDown(KeyCode.R);
    }

    private bool BrushThrewCheck()
    {
        return player.GetComponentInChildren<PlayerInstanceBrush_SCRPT>().brushThrew;
    }

    private void BrushMotion()
    {
        if (brushCalled)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;

            Vector3 offset = new Vector3(0.5f, 0, -0.5f);

            transform.position = Vector3.SmoothDamp(transform.position, inventory.handPos.position, ref velocity, returnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, inventory.handPos.rotation, 0.05f);
        }
    }

    private IEnumerator WaitUntilBrushReturns()
    {
        yield return new WaitUntil(() => Vector3.Distance(transform.position, player.position) < 1.5f);

        gameObject.GetComponent<BoxCollider>().enabled = false;

        brushCalled = false;

        inventory.AddItem(visualBrush);

        Destroy(this.gameObject);
    }
}
