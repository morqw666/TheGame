using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Renderer _renderer;
    private Bullet spawnedBullet;
    private Transform _shootingPosition;
    private int _damage;
    public int Damage
    {
        get => _damage;
        set
        {
            _damage = value;
        }
    }
    public Transform ShootingPosition
    {
        get => _shootingPosition;
        set
        {
            _shootingPosition = value;
        }
    }
    public void SetMaterial(ColoredMaterial material)
    {
        _renderer.sharedMaterial = material.Material;
    }
    public void FireBullet()
    {
        var bullet = Instantiate(_prefab);
        spawnedBullet = bullet;
        spawnedBullet.transform.position = spawnBullet.position;
        spawnedBullet.ShootingPosition = _shootingPosition;
        spawnedBullet.Damage = _damage;
    }
}
