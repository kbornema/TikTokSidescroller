using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField]
    private float _damage = 10.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();

        if(health != null && health.IsPlayer)
        {
            health.Change(-_damage);
        }
    }
}
