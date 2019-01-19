using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour {

    [SerializeField]
    private GameObject explosionFX;
    
	void Start () {
        EnemyBase.OnAnyEnemyKilled += HandleEnemyKilled;
        PlayerFrigate.OnPlayerDied += HandlePlayerKilled;
	}

    private void HandleEnemyKilled(EnemyBase eb, GameObject killer)
    {
        Destroy(Instantiate(explosionFX, eb.transform.position, Quaternion.identity), 1f);
    }

    private void HandlePlayerKilled(PlayerFrigate pf)
    {
        Destroy(Instantiate(explosionFX, pf.transform.position, Quaternion.identity), 1f);
    }

    private void OnDestroy()
    {
        EnemyBase.OnAnyEnemyKilled -= HandleEnemyKilled;
        PlayerFrigate.OnPlayerDied -= HandlePlayerKilled;
    }
}
