using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterBase c = collision.GetComponent<CharacterBase>();
        if (c != null)
        {
            c.TakeDamage(5);
        }
    }
}
