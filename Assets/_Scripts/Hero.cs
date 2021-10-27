using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform bulletSpawn;

    [SerializeField] private int _damage;

    public void ShootAt(Transform target)
    {
        var direction = target.position - bulletSpawn.position;
        var bullet = Instantiate(_prefab, bulletSpawn.position, Quaternion.LookRotation(direction));
        bullet.SetDamage(_damage);
    }
}
