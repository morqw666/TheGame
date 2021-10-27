using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed;
    private int _damage;
    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider collider)
    {
        Destroy(this.gameObject);
        var playerManager = FindObjectOfType<PlayerManager>();
        playerManager.TakeDamage(_damage);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
