using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {

    [SerializeField]
    private PlayerFrigate player;
    [SerializeField]
    private Camera mainCamera;

    private ObjectPool rockPool;

	void Start () {
        rockPool = ObjectPool.Instances["Rock"];
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.value < 0.2)
        {
            SpawnRock();
        }
	}

    void SpawnRock()
    {
        Vector2 playerDirection = player.transform.up;
        Vector3 deviation = Quaternion.AngleAxis(Random.Range(-80f, 80f), Vector3.forward) * playerDirection;
        deviation.x *= 1.5f;
        deviation.y *= 1.5f;
        deviation.z = 10;

        Vector3 spawnPoint = mainCamera.ViewportToWorldPoint(deviation);

        GameObject go = rockPool.GetObject();

        if (go != null)
        {
            float scale = Random.Range(1.0f, 1.25f);
            go.transform.localScale = new Vector3(scale,scale,scale);
            go.transform.position = spawnPoint;
            go.SetActive(true);
        }
    }
}
