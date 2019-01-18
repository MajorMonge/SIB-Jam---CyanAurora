using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrigate : CharacterBase {

    [SerializeField]
    private ParticleSystem pSysWave;

    public static event Action<PlayerFrigate> OnPlayerDied = delegate { };

    public override void TakeDamage(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        if (pSysWave != null)
        {
            pSysWave.transform.SetParent(null);
            pSysWave.Stop();
            Destroy(pSysWave.gameObject, pSysWave.main.startLifetime.constant);
        }

        OnPlayerDied(this);
        gameObject.SetActive(false);
    }
}
