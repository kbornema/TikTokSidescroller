using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private GameObject _root = default;
    public GameObject Root => _root;

    [SerializeField]
    private float _maxHealth = 100.0f;
    [SerializeField]
    private float _health = default;
    [SerializeField]
    private bool _isPlayer = false;
    public bool IsPlayer => _isPlayer;

    [SerializeField]
    private GUI_Healthbar _healthBar = default;

    [SerializeField]
    private bool _playAnimationOnDeath = true;
    [SerializeField]
    private List<GameObject> _objectsToDeactivate = default;
    [SerializeField]
    private ActorAnimation _animation = default;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void Change(float delta)
    {
        _health = Mathf.Clamp(_health + delta, 0.0f, _maxHealth);
        _healthBar?.Set(_health/_maxHealth);

        if(_health <= 0.0f)
        {
            if(_playAnimationOnDeath)
            {
                if(_animation)
                {
                    _animation.PlayDeath();
                }
            }

            var actor = _root.GetComponent<Actor>();
            actor.enabled = false;

            for (int i = 0; i < _objectsToDeactivate.Count; i++)
            {
                _objectsToDeactivate[i].SetActive(false);
            }
        }
    }
}
