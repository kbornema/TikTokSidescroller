using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator = default;
    [SerializeField]
    private Actor _actor = default;
    [SerializeField, Range(0.0f, 1.0f)]
    private float _movingDirTreshold = 1.0f;
    [SerializeField]
    private float _animTimeRunning = 1.0f;
    [SerializeField]
    private float _jumpTreshold = 1.0f;

    private void LateUpdate()
    {
        var dir = _actor.Direction;

        if (dir.x != 0.0f)
        {
            float x = dir.x;
            var scale = transform.localScale;
            float sign = Mathf.Sign(x);
            scale.x = Mathf.Abs(scale.x) * sign;
            transform.localScale = scale;
        }

        var body = _actor.Body;
        var veloY = body.velocity.y;
        var isJumping = Mathf.Abs(veloY) > _jumpTreshold;

        //_animator.SetBool("IsJumping", isJumping);
        _animator.SetBool("IsMoving", Mathf.Abs(dir.x) > _movingDirTreshold);
        _animator.SetFloat("AnimSpeed", 1.0f / _animTimeRunning);
    }

    public void PlayDeath()
    {
        _animator.SetBool("IsDead", true);
    }
}
