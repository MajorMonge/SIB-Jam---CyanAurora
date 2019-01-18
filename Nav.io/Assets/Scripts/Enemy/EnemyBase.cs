using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : CharacterBase, IPoolable {

    [SerializeField]
    private int scoreOnKill = 0;

    public int ScoreOnKill
    {
        get
        {
            return scoreOnKill;
        }

        set
        {
            scoreOnKill = value;
        }
    }

    public static event Action<EnemyBase> OnAnyEnemyKilled = delegate { };

    public override void TakeDamage(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void OnEnable()
    {
        OnSpawn();
    }

    public override void Die()
    {
        OnAnyEnemyKilled(this);
        OnDespawn();
        gameObject.SetActive(false);
    }

    public abstract void OnSpawn();
    public abstract void OnDespawn();
}
