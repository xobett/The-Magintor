using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushCollision : MonoBehaviour
{
    private Rigidbody brushRb;

    private Material brushMaterial;

    [SerializeField] private float downForceOnCollision;

    public bool brushCollided;

    [SerializeField] private GameObject visualBrush;

    private void Update()
    {
        if (brushCollided)
        {
            brushRb.AddForce(-transform.up * downForceOnCollision);
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!brushCollided)
        {
            gameObject.GetComponent<BrushMovement>().brushSpeed = 0;
            gameObject.GetComponent<BrushMovement>().brushTurnSpeed = 0;

            brushRb = GetComponent<Rigidbody>();
            brushRb.useGravity = true;

            brushCollided = true;

            StartCoroutine(ReturnCamToPlayer());
        }
    }

    private IEnumerator ReturnCamToPlayer()
    {
        GameObject playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

        yield return new WaitForSeconds(0.2f);

        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInstanceBrush_SCRPT>().brushThrew = false;
        playerCamera.GetComponent<PlayerCamera_SCRPT>().returnCameraToPlayer = true;

        Instantiate(visualBrush, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
