using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDoor : MonoBehaviour
{
    public bool purpleDoor;
    public bool greenDoor;
    public bool blueDoor;
    public bool redDoor;

    private string requiredTag;

    private Material doorMaterial;

    [Header("REQUIRED PAINT MATERIALS")]

    [SerializeField] private Material bluePaintMat;
    [SerializeField] private Material purplePaintMat;
    [SerializeField] private Material redPaintMat;
    [SerializeField] private Material requiredPaintMat;

    private Color requiredPaintColor;

    private void Start()
    {
        doorMaterial = transform.parent.gameObject.GetComponent<Renderer>().material;
    }

    void Update()
    {
        DoorPaintCheck();
    }

    private void DoorPaintCheck()
    {
        if (purpleDoor)
        {
            transform.parent.tag = "Purple Door";
            requiredPaintMat = purplePaintMat;
            doorMaterial.color = Color.magenta;
        }
        else if (greenDoor)
        {
            transform.parent.tag = "Green Door";
            requiredPaintColor = Color.green;
            doorMaterial.color = Color.green;
        }
        else if (blueDoor)
        {
            transform.parent.tag = "Blue Door";
            requiredPaintMat = bluePaintMat;
            doorMaterial.color = Color.blue;
        }
        else if (redDoor)
        {
            transform.parent.tag = "Red Door";
            requiredPaintMat = redPaintMat;
            doorMaterial.color = Color.red;
        }
        else
        {
            transform.parent.tag = "Plain Door";
            doorMaterial.color = Color.white;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Moving Brush"))
        {
            if (collision.gameObject.GetComponent<PaintBrush_SCRPT>().brushMaterial == requiredPaintMat)
            {
                Debug.Log("Should destroy");
                AudioManager.instance.PlaySfx(AudioManager.instance.destroyedPaintDoorClip);
                transform.parent.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                Destroy(transform.parent.gameObject);
            }
        }

    }
}

