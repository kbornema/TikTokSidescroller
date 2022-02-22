using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField]
    private PlayerController _player = default;
    public PlayerController Player => _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var coin = collision.GetComponent<Coin>();

        if (coin != null)
        {
            coin.PlaySfx();
            _player.AddCoins(1);
            GameObject.Destroy(coin.gameObject);
        }
    }
}
