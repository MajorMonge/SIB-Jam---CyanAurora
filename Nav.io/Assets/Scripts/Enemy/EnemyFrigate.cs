using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrigate : EnemyBase {

    [SerializeField]
    private ParticleSystem pSysWave;

    private static Camera mainCamera;

    private void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
    }

    void Update()
    {
        ParticleSystem.MainModule mm = pSysWave.main;
        mm.startRotationZ = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;

        Vector3 vp = mainCamera.WorldToViewportPoint(transform.position);

        if (vp.x < -1f || vp.x > 2f || vp.y < -1f || vp.y > 2f)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetObject()
    {

    }

    public override void OnSpawn()
    {
        if (pSysWave != null)
        {
            pSysWave.transform.SetParent(transform);
            pSysWave.transform.localPosition = Vector3.zero;
            pSysWave.Play();
        }
    }

    public override void OnDespawn()
    {
        if (pSysWave != null)
        {
            pSysWave.transform.SetParent(null);
            pSysWave.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerFrigate pf = collision.GetComponent<PlayerFrigate>();

            pf.TakeDamage(100, gameObject);
            TakeDamage(100, gameObject);
        }
    }
}
