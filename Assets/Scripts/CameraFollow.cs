using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target = default;
    [SerializeField]
    private Vector3 _offset = default;
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private float _reachDistance = 0.1f;

    private void LateUpdate()
    {
        if(_target != null)
        {
            var targetPos = _target.position + _offset;
            var toTarget = targetPos - transform.position;
            toTarget.z = 0.0f;
            var dist = toTarget.magnitude;

            if(dist > _reachDistance)
            {
                //toTarget.Normalize();
                transform.position += toTarget * _speed * Time.deltaTime;
            }
        }
    }
}
