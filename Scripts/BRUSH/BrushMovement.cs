using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BrushMovement : MonoBehaviour
{
    private Rigidbody brushRb;

    public float brushSpeed;
    public float brushTurnSpeed;

    [SerializeField] private float horizontalInput;

    void Start()
    {
        brushRb = GetComponent<Rigidbody>();

        Application.targetFrameRate = 60;
    }

    void Update()
    {
        //Movement();
        GetHorizontalInput();   
    }

    private void Movement()
    {
        brushRb.velocity = (transform.forward * brushSpeed);

        Quaternion brushRotation = Quaternion.Euler(new Vector3(0, horizontalInput * brushTurnSpeed * Time.deltaTime, 0));
        brushRb.MoveRotation(brushRb.rotation * brushRotation);
    }

    private void GetHorizontalInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        brushRb.velocity = (transform.forward * brushSpeed);

        Quaternion brushRotation = Quaternion.Euler(new Vector3(0, horizontalInput * brushTurnSpeed * Time.deltaTime, 0));
        brushRb.MoveRotation(brushRb.rotation * brushRotation);
    }
}