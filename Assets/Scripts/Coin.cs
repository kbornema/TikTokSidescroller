using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 1.0f;
    [SerializeField]
    private AudioSource _sfxPrefab = default;

    private void Update()
    {
        transform.Rotate(new Vector3(0.0f, _rotateSpeed * Time.deltaTime, 0.0f));
    }

    public void PlaySfx()
    {
        Helper.InstantiateAndCreate(_sfxPrefab, transform.position);
    }
}
