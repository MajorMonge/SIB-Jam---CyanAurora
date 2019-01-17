using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField, Range(0,1f)]
    private float rotationLerpSpeed = 0.1f;

    private Vector3 axis;

	void Update () {
        GetInput();
        
        Move();
	}

    private void GetInput()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        float rotationDrag = 1f;

        if (axis.magnitude > 0)
        {
            Quaternion to = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.up, axis, Vector3.forward));
            transform.rotation = Quaternion.Lerp(transform.rotation, to, rotationLerpSpeed);

            rotationDrag = Vector3.Angle(Vector3.up, axis) / 180;
        }


        transform.position += axis * moveSpeed * Time.deltaTime * rotationDrag;
    }
}
