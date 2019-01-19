using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private PlayerFrigate player;
    [SerializeField]
    private Camera mainCamera;

    private ObjectPool enemyPool;

    void Start()
    {
        enemyPool = ObjectPool.Instances["Enemy"];
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < 0.05f)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector2 playerDirection = player.transform.up;
        Vector3 deviation = Quaternion.AngleAxis(Random.Range(-80f, 80f), Vector3.forward) * playerDirection;
        deviation.x *= 1.5f;
        deviation.y *= 1.5f;
        deviation.z = 10;

        Vector3 spawnPoint = mainCamera.ViewportToWorldPoint(deviation);

        GameObject go = enemyPool.GetObject();

        if (go != null)
        {
            go.transform.position = spawnPoint;
            go.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));
            go.SetActive(true);
        }
    }
}
