using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowAnimation : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _target = default;
    [SerializeField]
    private AnimationCurve _alphaCurve = default;
    [SerializeField]
    private float _time = default;

    private float _curTime = 0.0f;

    [SerializeField]
    private bool _destroyOnEnd = false;
    [SerializeField]
    private GameObject _destroyTarget = default;

    private void OnEnable()
    {
        _curTime = 0.0f;
    }

    private void Update()
    {
        _curTime += Time.deltaTime;
        float t = _curTime / _time;
        var alpha = _alphaCurve.Evaluate(t);
        var color = _target.color;
        color.a = alpha;
        _target.color = color;

        if(t >= 1.0f && _destroyOnEnd && _destroyTarget != null)
        {
            _destroyTarget.SetActive(false);
        }
    }
}
