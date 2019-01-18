using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrigate : EnemyBase {

    [SerializeField]
    private ParticleSystem pSysWave;

    void Update()
    {
        ParticleSystem.MainModule mm = pSysWave.main;
        mm.startRotationZ = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
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
}
