using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamera_SCRPT : MonoBehaviour
{
    [Header("CAMERA SETTINGS")]

    public float mouseSensitivity;
    public float lookUpLimit;
    public float lookDownLimit;

    private float xMouse;
    private float yMouse;

    private float xRotation;

    [Header("FOLLOW BRUSH SETTINGS")]

    public float returnCameraSpeed;
    public float followBrushSpeed;
    public float distance;
    public float verticalAngle;

    private GameObject movingBrush;

    private Vector3 velocity = Vector3.zero;
    public Vector3 offset;

    [Header("BOOLEANS CHECK")]

    public bool returnCameraToPlayer;
    public bool brushThrew;
    private Transform playerTransform;
    [SerializeField] private Transform playerCameraPosition;

    void Start()
    {
        playerTransform = transform.parent;

        Cursor.lockState = CursorLockMode.Locked;

        Application.targetFrameRate = 60;
    }

    void Update()
    {
        CameraMovement();
        ReturnCamera();
        BrushThrew();
    }

    private void CameraMovement()
    {
        GetMouseInput();

        if (!brushThrew)
        {
            xRotation -= yMouse;
            xRotation = Mathf.Clamp(xRotation, lookUpLimit, lookDownLimit);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerTransform.Rotate(Vector3.up * xMouse);
        }
    }

    private void ReturnCamera()
    {
        if (returnCameraToPlayer)
        {
            StartCoroutine(ReturnCame());
            transform.rotation = Quaternion.Slerp(transform.rotation, playerCameraPosition.rotation, 0.1f);
        }
    }

    private void BrushThrew()
    {
        try
        {
            brushThrew = transform.parent.GetChild(4).GetComponent<PlayerInstanceBrush_SCRPT>().brushThrew;

        }
        catch
        {
            brushThrew = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInstanceBrush_SCRPT>().brushThrew;

        }
    }

    private void GetMouseInput()
    {
        xMouse = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (brushThrew)
        {
            if (GameObject.FindGameObjectWithTag("Moving Brush"))
            {
                GetComponent<CameraHeadBob>().enabled = false;
                movingBrush = GameObject.FindGameObjectWithTag("Moving Brush");

                //Camera rotation
                Quaternion lookDownAtBrush = Quaternion.Euler(verticalAngle, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, movingBrush.transform.rotation * lookDownAtBrush, followBrushSpeed * Time.deltaTime);

                //Camera position
                Vector3 followBrushPos = movingBrush.transform.position - movingBrush.transform.forward * distance + offset;
                transform.position = Vector3.SmoothDamp(transform.position, followBrushPos, ref velocity, 1f / followBrushSpeed * Time.deltaTime);
            }
        }
        else
        {
            movingBrush = null;
        }
    }

    private IEnumerator ReturnCame()
    {
        //Moves camera position towards the player
        transform.position = Vector3.SmoothDamp(transform.position, playerCameraPosition.position, ref velocity, 1f / returnCameraSpeed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, playerCameraPosition.rotation, 1f);

        //Waits until camera reaches player
        yield return new WaitUntil(() => Vector3.Distance(transform.position, playerCameraPosition.position) < 0.1f);

        returnCameraToPlayer = false;
        xRotation = 0;

        transform.parent.GetComponentInChildren<PlayerInstanceBrush_SCRPT>().brushThrew = false;
        GameObject.FindObjectOfType<PlayerTeleport_SCRPT>().playerIsTeleporting = false;

        GetComponent<CameraHeadBob>().enabled = true;

        yield return null;
    }
}
