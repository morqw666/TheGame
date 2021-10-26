using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed; 
    private Transform _shootingPosition;
    private readonly List<int> DamageAmount = new List<int>() { 1, 3, 8, 20 };
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
    void OnTriggerEnter(Collider collider)
    {
        Destroy(this.gameObject);
        var playerManager = FindObjectOfType<PlayerManager>();
        int damage = DamageAmount[_damage];
        playerManager.TakeDamage(damage);
    }
    private void FireBullet()
    {
        var bullet = this.transform.position;
        this.transform.position = Vector3.MoveTowards(bullet, _shootingPosition.transform.position, _speed * Time.deltaTime);
        this.transform.rotation = Quaternion.LookRotation(_shootingPosition.transform.position);

        //var bullet = this.transform.position;
        //Vector3 dir = (_shootingPosition.transform.position - this.transform.position).normalized;
        //this.transform.position = Vector3.MoveTowards(bullet, bullet + dir*10, _speed * Time.deltaTime);

        //if (bullet == _shootingPosition.transform.position)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    private void Update()
    {
        FireBullet();
    }
}
