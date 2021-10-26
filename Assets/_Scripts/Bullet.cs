using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _pos;
    [SerializeField] private int _speed;
    private PlayerManager playerManager;
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }
    private void FireBullet()
    {
        if (playerManager.CurrentPlayer())
        {
            _pos = 28;
        }
        else
        {
            _pos = 47;
        }
        var bullet = this.transform.position;
        var position = new Vector3(bullet.x, bullet.y, _pos);
        this.transform.position = Vector3.MoveTowards(bullet, position, _speed * Time.deltaTime);
        if (bullet.z == position.z)
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        FireBullet();
    }
}
