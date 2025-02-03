using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraHeadBob : MonoBehaviour
{
    [SerializeField] private float magnitude;

    [Header("HEAD BOB SETTINGS")]

    [SerializeField] private float verticalAmplitude;
    [SerializeField] private float verticalFrequency;
    [SerializeField] private float horizontalAmplitude;
    [SerializeField] private float horizontalFrequency;

    [SerializeField] private GameObject player;

    private Vector3 startPos;
    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        SearchPlayer();
        PlayerIsMoving();
        ResetCameraPos();
    }

    private void PlayerIsMoving()
    {
        magnitude = player.GetComponent<CharacterController>().velocity.magnitude;

        float xMov = FindObjectOfType<PlayerMovement_SCRPT>().xMovement;
        float zMov = FindObjectOfType<PlayerMovement_SCRPT>().zMovement;

        if (Mathf.Abs(xMov) > 0f || Mathf.Abs(zMov) > 0f)
        {
            StartHeadBob();
        }
    }

    private void StartHeadBob()
    {
        //Head Vertical && Horizontal Movement
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude, 1 * Time.deltaTime);
        pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.time * horizontalFrequency) * horizontalAmplitude * 2, 1 * Time.deltaTime);

        transform.localPosition += pos;
    }

    private void ResetCameraPos()
    {
        //Returns camera position to its initial when player is not moving
        if (transform.localPosition != startPos)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, 1 * Time.deltaTime);
        }
    }

    private void SearchPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
