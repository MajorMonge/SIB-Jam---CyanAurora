using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    [SerializeField]
    private string instanceName;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int initialQuantity = 20;
    [SerializeField]
    private bool expandable = false;

    private List<GameObject> pool;

    public static Dictionary<string, ObjectPool> Instances { get; private set; }

    private void Awake()
    {
        if (Instances == null) Instances = new Dictionary<string, ObjectPool>();
        Instances.Add(instanceName, this);

        pool = new List<GameObject>();

        for (int i = 0; i < initialQuantity; i++)
        {
            GameObject go = Instantiate(prefab);
            go.SetActive(false);

            pool.Add(go);
        }
    }

    public GameObject GetObject()
    {
        GameObject go = pool.Find(x => !x.activeInHierarchy);

        if (go == null && expandable)
        {
            go = Instantiate(prefab);
            pool.Add(go);
        }

        return go;
    }

    private void OnDestroy()
    {
        Instances.Clear();
    }
}
