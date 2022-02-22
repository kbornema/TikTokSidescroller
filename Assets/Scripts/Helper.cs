using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static void InstantiateAndCreate(AudioSource prefab, Vector2 pos)
    {
        if (prefab)
        {
            var sfx = GameObject.Instantiate(prefab, pos, Quaternion.identity);
            sfx.Play();
            GameObject.Destroy(sfx.gameObject, sfx.clip.length + 0.5f);
        }
    }
}
