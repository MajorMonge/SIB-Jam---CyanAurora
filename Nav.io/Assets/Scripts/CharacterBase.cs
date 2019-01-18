using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour {

    [SerializeField]
    protected int hitPoints;

    public abstract void TakeDamage(int damage);
    public abstract void Die();
}
