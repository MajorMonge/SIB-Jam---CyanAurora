using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    private PlayerFrigate player;
    [SerializeField]
    private BulletData bulletData;
    [SerializeField]
    private Transform shootPoint;

    private bool shoot = false;

	// Update is called once per frame
	void Update () {
        GetInput();
        if (shoot) Shoot();
	}

    private void GetInput()
    {
        shoot = Input.GetButtonDown("Fire1");
    }

    private void Shoot()
    {
        GameObject go = ObjectPool.Instances["Bullet"].GetObject();

        if (go == null) return;

        Bullet bullet = go.GetComponent<Bullet>();

        BulletData bd = bulletData;
        bd.direction = shootPoint.position - transform.position;

        go.transform.position = shootPoint.position;
        bullet.SetupAndActivate(player, bd);
    }

}
