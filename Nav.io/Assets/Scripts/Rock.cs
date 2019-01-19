using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    private static Camera mainCamera;

    private void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 vp = mainCamera.WorldToViewportPoint(transform.position);

        if (vp.x < -0.5f || vp.x > 1.5f || vp.y < -0.5f || vp.y > 1.5f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterBase c = collision.GetComponent<CharacterBase>();
        if (c != null)
        {
            c.TakeDamage(5, gameObject);
        }
    }
}
