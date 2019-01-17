using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    private PlayerFrigate player;
    [SerializeField]
    private BulletData bulletData;
    [SerializeField, Range(1f, 60f)]
    private float fireRate = 10f;
    [SerializeField]
    private Transform shootPoint;

    private float shootTimer = 0f;

    private bool shoot = false;

	// Update is called once per frame
	void Update () {
        shootTimer -= Time.deltaTime;

        GetInput();
        if (shoot && shootTimer <= 0f) Shoot();
	}

    private void GetInput()
    {
        shoot = Input.GetButtonDown("Fire1");
    }

    private void Shoot()
    {
        shootTimer = 1 / fireRate;

        GameObject go = ObjectPool.Instances["Bullet"].GetObject();

        if (go == null) return;

        Bullet bullet = go.GetComponent<Bullet>();

        BulletData bd = bulletData;
        bd.direction = shootPoint.position - transform.position;

        go.transform.position = shootPoint.position;
        bullet.SetupAndActivate(player, bd);
    }

}
