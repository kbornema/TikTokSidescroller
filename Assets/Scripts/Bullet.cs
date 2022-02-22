using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _body = default;
    [SerializeField]
    private float _speed = 15.0f;
    [SerializeField]
    private float _damage = 25.0f;

    private Vector2 _direction = default;

    private void FixedUpdate()
    {
        _body.position += _direction * _speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();

        if(health != null && !health.IsPlayer)
        {
            health.Change(-_damage);
            GameObject.Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 dir)
    {
        _direction = dir.normalized;
    }
}

