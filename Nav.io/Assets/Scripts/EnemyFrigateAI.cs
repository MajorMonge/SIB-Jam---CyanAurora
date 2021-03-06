﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrigateAI : StateMachine {

    [SerializeField, Range(1f,20f)]
    private float patrolSpeed = 2f;
    [SerializeField, Range(1f, 20f)]
    private float chaseSpeed = 5f;
    [SerializeField, Range(0f, 1f)]
    private float rotationLerpSpeed = 0.1f;
    [SerializeField, Range(5f, 50f)]
    private float sightRadius;
    [SerializeField, Range(1f, 60f)]
    private float fireRate = 10f;
    [SerializeField]
    private BulletData bulletData;

    public float ChaseSpeed
    {
        get
        {
            return chaseSpeed;
        }

        set
        {
            chaseSpeed = value;
        }
    }
    public float PatrolSpeed
    {
        get
        {
            return patrolSpeed;
        }

        set
        {
            patrolSpeed = value;
        }
    }
    public float RotationLerpSpeed
    {
        get
        {
            return rotationLerpSpeed;
        }

        set
        {
            rotationLerpSpeed = value;
        }
    }
    public float SightRadius
    {
        get
        {
            return sightRadius;
        }

        set
        {
            sightRadius = value;
        }
    }
    public float FireRate
    {
        get
        {
            return fireRate;
        }

        set
        {
            fireRate = value;
        }
    }
    public BulletData BulletData
    {
        get
        {
            return bulletData;
        }

        set
        {
            bulletData = value;
        }
    }

    private void OnEnable()
    {
        ChangeState(new PatrollingState());
    }
}
