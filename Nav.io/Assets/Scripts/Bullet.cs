using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable {
    
    public CharacterBase Owner { get; private set; }

    [System.NonSerialized]
    private BulletData data;

    private Coroutine lifespanCountdown;

    public void SetupAndActivate(CharacterBase shooter, BulletData bulletData)
    {
        Owner = shooter;
        data = bulletData;
        gameObject.SetActive(true);

        if (data.lifeTime > 0)
        {
            lifespanCountdown = StartCoroutine(LifespanCountdown());
        }
    }

    void Update()
    {
        transform.position += data.direction * data.speed * Time.deltaTime;
    }

    private IEnumerator LifespanCountdown()
    {
        float t = data.lifeTime;

        while (t > 0)
        {
            t -= Time.deltaTime;
            yield return null;
        }

        OnDespawn();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterBase cb = collision.GetComponent<CharacterBase>();

        if (cb != null)
        {
            if (cb == Owner) return;

            cb.TakeDamage(data.damage, gameObject);
        }

        OnDespawn();
        gameObject.SetActive(false);
    }

    public void OnSpawn()
    {

    }

    public void OnDespawn()
    {
        StopCoroutine(lifespanCountdown);
    }
}
