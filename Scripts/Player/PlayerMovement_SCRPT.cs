using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_SCRPT : MonoBehaviour
{
    private CharacterController characterController;

    public bool brushThrew;

    [Header("GRAVITY SETTINGS")]

    [SerializeField] private float gravity;
    [SerializeField] private float groundCheckRadius;

    [SerializeField] private LayerMask groundCheckLayerMask;

    private Vector3 downForce;

    [SerializeField] private Transform groundCheckPos;

    [SerializeField] private bool isGrounded;

    [Header("MOVEMENT SETTINGS")]

    public float movementSpeed;

    public float xMovement;
    public float zMovement;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        PlayerMovement();
        BrushThrewCheck();
        IsGroundedCheck();
    }

    private void PlayerMovement()
    {
        if (!brushThrew)
        {
            xMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            zMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

            Vector3 movement = transform.right * xMovement + transform.forward * zMovement;

            characterController.Move(movement);

            if (!isGrounded)
            {
                downForce.y += gravity * Time.deltaTime;
            }
            else
            {
                downForce.y = -1f;
            }

            characterController.Move(downForce * Time.deltaTime);
        }
    }

    private void BrushThrewCheck()
    {
        brushThrew = GetComponentInChildren<PlayerInstanceBrush_SCRPT>().brushThrew;
    }

    private void IsGroundedCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckPos.position, groundCheckRadius, groundCheckLayerMask);
    }
}
