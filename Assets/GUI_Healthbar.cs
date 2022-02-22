using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Healthbar : MonoBehaviour
{
    [SerializeField]
    private Image _fill = default;

    public void Set(float t)
    {
        _fill.fillAmount = t;
    }
}
