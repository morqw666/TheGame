using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform spawnBullet;

    [SerializeField] private int _damage;
    public void SetMaterial(ColoredMaterial material)
    {
        _renderer.sharedMaterial = material.Material;
    }
    public void ShootAt(Transform target)
    {
        var direction = target.position - spawnBullet.position;
        var bullet = Instantiate(_prefab, spawnBullet.position, Quaternion.LookRotation(direction));
        bullet.SetDamage(_damage);
    }
}
