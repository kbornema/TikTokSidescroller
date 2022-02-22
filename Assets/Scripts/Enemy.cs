using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    [SerializeField]
    private Transform _a;
    [SerializeField]
    private Transform _b;

    private float _curTime;

    private bool _isTargetA;

    private void Awake()
    {
        _isTargetA = true;
    }

    private void Update()
    {
        Vector2 toTarget = new Vector2();

        if (_a != null && _b != null)
        {
            if (_isTargetA)
            {
                toTarget = _a.position - transform.position;
            }
            else
            {
                toTarget = _b.position - transform.position;
            }
        }
        toTarget.y = 0.0f;

        if (toTarget.magnitude <= 0.01f)
        {
            _isTargetA = !_isTargetA;
        }

        toTarget.Normalize();
        _direction = toTarget;

    }
}
