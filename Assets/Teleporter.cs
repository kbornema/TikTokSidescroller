using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public enum EType { In, Out }

    [SerializeField]
    private Transform _target;
    [SerializeField]
    private EType _type = EType.In;
    [SerializeField]
    private AudioSource _sfxPrefab = default;
    [SerializeField]
    private GameObject _vfx = default;

    private void Start(){}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!enabled)
        {
            return;
        }

        if (_type == EType.In && _target != null)
        {
            var playerCollector = collision.GetComponent<CoinCollector>();

            if (playerCollector != null)
            {
                if (_vfx != null)
                {
                    _vfx.SetActive(true);
                }

                var player = playerCollector.Player;
                player.transform.position = _target.position;
                Helper.InstantiateAndCreate(_sfxPrefab, _target.position);
            }
        }
    }
}
