using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Special effects controller, enable special effect instantiation, 
/// Such as when a player picks up a coin, 
/// </summary>
public class SFXCtrl : MonoBehaviour
{
    public static SFXCtrl instance;
    public SFX sfx;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ShowCoinPickUpEffect(Vector3 pos)
    {
        Instantiate(sfx.sfxCoinPickUp, pos, Quaternion.identity);
    }
    public void ShowBulletPickUpEffect(Vector3 pos)
    {
        Instantiate(sfx.sfxBulletPickUp, pos, Quaternion.identity);
    }
}
