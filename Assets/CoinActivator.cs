using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinActivator : MonoBehaviour
{
    [SerializeField]
    private List<Coin> _coins = default;

    [SerializeField]
    private List<GameObject> _activate = default;
    [SerializeField]
    private List<GameObject> _deactivate = default;

    private void Update()
    {
        _coins.RemoveAll(x => x == null);

        if(_coins.Count <= 0)
        {
            enabled = false;
            SetActive(_activate, true);
            SetActive(_deactivate, false);
        }
    }

    private void SetActive(List<GameObject> objs, bool active)
    {
        for (int i = 0; i < objs.Count; i++)
        {
            objs[i].SetActive(active);
        }
    }
}
