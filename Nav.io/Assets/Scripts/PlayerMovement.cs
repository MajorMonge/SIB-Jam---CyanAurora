using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private ParticleSystem pSysWave;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField, Range(0,1f)]
    private float rotationLerpSpeed = 0.1f;

    private Vector3 axis;

    private bool moved;

	void Update () {
        GetInput();
        
        Move();
	}

    private void GetInput()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");

        moved = Input.GetButton("Horizontal") || Input.GetButton("Vertical");
    }

    private void Move()
    {
        float rotationDrag = 1f;

        if (moved)
        {
            Quaternion to = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.up, axis, Vector3.forward));
            transform.rotation = Quaternion.Lerp(transform.rotation, to, rotationLerpSpeed);

            ParticleSystem.MainModule mm = pSysWave.main;
            mm.startRotation = to.eulerAngles.z * Mathf.Deg2Rad;

            rotationDrag = 1 - (Quaternion.Angle(transform.rotation, to) / 180);

            if (pSysWave.isStopped || pSysWave.isPaused || !pSysWave.isEmitting) pSysWave.Play();
        }

        if (!moved)
        {
            if (pSysWave.isPlaying) pSysWave.Stop();
        }


        transform.position += axis * moveSpeed * Time.deltaTime * rotationDrag;
    }
}
