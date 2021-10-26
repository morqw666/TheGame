using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed;
    private int _damage;

    //private Transform _shootingPosition;
    //private readonly List<int> DamageAmount = new List<int>() { 1, 3, 8, 20 };
    //public int Damage
    //{
    //    get => _damage;
    //    set
    //    {
    //        Debug.LogError("SET: " + value);
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

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Destroy(this.gameObject);
        var playerManager = FindObjectOfType<PlayerManager>();
        //int damage = DamageAmount[_damage];
        //Debug.LogError(damage);
        playerManager.TakeDamage(_damage);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
