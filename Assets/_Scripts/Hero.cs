using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform spawnBullet;

    //private Bullet spawnedBullet;
    //private Transform _shootingPosition;
    [SerializeField] private int _damage;
    //public int Damage
    //{
    //    get => _damage;
    //    set
    //    {
    //        _damage = value;
    //    }
    //}

    //public Transform ShootingPosition
    //{
    //    get => _shootingPosition;
    //    set
    //    {
    //        _shootingPosition = value;
    //    }
    //}
    public void SetMaterial(ColoredMaterial material)
    {
        _renderer.sharedMaterial = material.Material;
    }
    //public void FireBullet()
    //{
    //    ShootAt(_shootingPosition);
    //    //var bullet = Instantiate(_prefab);
    //    //spawnedBullet = bullet;
    //    //spawnedBullet.transform.position = spawnBullet.position;
    //    //spawnedBullet.ShootingPosition = _shootingPosition;
    //    //spawnedBullet.Damage = _damage;
    //}

    public void ShootAt(Transform target)
    {
        var direction = target.position - spawnBullet.position;
        var bullet = Instantiate(_prefab, spawnBullet.position, Quaternion.LookRotation(direction));
        bullet.SetDamage(_damage);
    }
}
