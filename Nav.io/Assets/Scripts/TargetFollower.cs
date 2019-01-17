using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField, Range(0,1f)]
    private float lerpVelocity = 1f;

    private void LateUpdate()
    {
        Vector3 relativePosition = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, relativePosition, lerpVelocity);
    }
}
