using UnityEngine;

[System.Serializable]
public struct BulletData
{
    [System.NonSerialized]
    public Vector3 direction;
    public float speed;
    public int damage;
    public float lifeTime;
}
