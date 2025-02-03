using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    private Rigidbody trapRb;
    private Transform trapPos;

    private Vector3 trapStartPos;
    private Vector3 velocity = Vector3.zero;

    private bool returnToStart;

    [SerializeField] private int waitTimeAfterHit;
    private float smoothTime = 0.01f;

    private AudioSource trapAudioSource;

    private void Start()
    {
        trapRb = transform.parent.GetChild(0).GetComponent<Rigidbody>();
        trapPos = transform.parent.GetChild(0).transform;

        trapStartPos = trapPos.position;

        trapAudioSource = transform.GetChild(0).GetComponent<AudioSource>();

    }

    private void Update()
    {
        ReturnTrapUpwards();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !returnToStart)
        {
            trapRb.useGravity = true;

            trapAudioSource.Play();

            StartCoroutine(WaitTime());
        }
    }

    private void ReturnTrapUpwards()
    {
        if (returnToStart)
        {
            trapPos.position = Vector3.SmoothDamp(trapPos.position, trapStartPos, ref velocity, 1f /smoothTime * Time.deltaTime); 

            if (Vector3.Distance(trapPos.position, trapStartPos) < 0.1)
            {
                returnToStart = false;
            }
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTimeAfterHit);

        trapRb.useGravity = false;
        returnToStart = true;

        yield return null;
    }
}
