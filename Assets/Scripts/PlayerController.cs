using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    [SerializeField]
    public float _jumpForce = 1.0f;
    [SerializeField]
    public float _jumpAdd = 1.0f;
    [SerializeField]
    public int _jumpPowerUpCoins = 5;
    [SerializeField]
    private TMPro.TextMeshProUGUI _text = default;

    private float _totalJumpAdd = 0.0f;

    private int _coins;
    public int Coins => _coins;

    private void Awake()
    {
        UpdateText();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        _direction.x = x;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _body.AddForce(Vector2.up * (_jumpForce + _totalJumpAdd), ForceMode2D.Impulse);
        }
    }

    public void AddCoins(int count)
    {
        _coins += count;

        if(_coins % _jumpPowerUpCoins == 0)
        {
            _totalJumpAdd += _jumpAdd;
        }

        UpdateText();
    }

    private void UpdateText()
    {
        if (_text != null)
        {
            _text.text = "Coins: " + _coins.ToString();
        }
    }
}
