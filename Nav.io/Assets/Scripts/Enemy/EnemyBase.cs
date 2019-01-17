using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : CharacterBase {

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

    public void OnDestroy()
    {
        OnAnyEnemyKilled(this);
    }
}
