using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koriboh : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.0f;
    [SerializeField]
    private Transform _target = default;
    [SerializeField]
    private float _timer = 0.5f;
    [SerializeField]
    private float _maxDist = 1.0f;

    private float _curTime;

    private Vector3 _targetOffset;

    private void LateUpdate()
    {
        _curTime -= Time.deltaTime;

        if (_curTime <= 0.0f)
        {
            _targetOffset = UnityEngine.Random.insideUnitSphere * _maxDist;
            _targetOffset.z = 0.0f;
            _curTime = _timer;
        }

        var targetPos = _target.position + _targetOffset;

        var toTarget = targetPos - transform.position;
        float distSq = toTarget.sqrMagnitude;
        toTarget.Normalize();
        transform.position += toTarget * distSq * _speed * Time.deltaTime;
    }
}
