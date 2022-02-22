using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D _body = default;
    public Rigidbody2D Body => _body;
    [SerializeField]
    protected float _speed = 1.0f;
    public float Speed => _speed;
    [SerializeField]
    protected Vector2 _direction = default;
    public Vector2 Direction => _direction;

    protected virtual void FixedUpdate()
    {
        _body.position += _direction * _speed * Time.fixedDeltaTime;
    }
}
