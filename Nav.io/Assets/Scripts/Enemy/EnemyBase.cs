using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : CharacterBase, IPoolable {

    [SerializeField]
    private int scoreOnKill = 0;

    private GameObject killer;

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

    public static event Action<EnemyBase, GameObject> OnAnyEnemyKilled = delegate { };

    public override void TakeDamage(int damage, GameObject source)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            killer = source;
            Die();
        }
    }

    private void OnEnable()
    {
        OnSpawn();
    }

    public override void Die()
    {
        OnAnyEnemyKilled(this, killer);
        OnDespawn();
        gameObject.SetActive(false);
        killer = null;
    }

    public abstract void OnSpawn();
    public abstract void OnDespawn();
}
