using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Bullet _bulletPrefab = default;
    [SerializeField]
    private PlayerController _player = default;
    [SerializeField]
    private float _cooldown = default;
    [SerializeField]
    private AudioSource _audioPrefab = default;

    private float _curCooldown = default;

    private void Update()
    {
        _curCooldown -= Time.deltaTime;

        if (_curCooldown <= 0.0f && Input.GetKey(KeyCode.Space))
        {
            Fire(_player.Direction);
            _curCooldown = _cooldown;
        }
    }

    public void Fire(Vector2 dir)
    {
        if(dir == Vector2.zero)
        {
            dir = Vector2.right;
        }

        Helper.InstantiateAndCreate(_audioPrefab, transform.position);

        var instance = GameObject.Instantiate(_bulletPrefab);
        instance.transform.position = transform.position;
        instance.SetDirection(dir);
    }
}
