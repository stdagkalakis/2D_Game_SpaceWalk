using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour
{
    public static SFXCtrl instance;
    public SFX sfx;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }



    /// <summary>
    /// Shows coin effect when the player collects the coin
    /// </summary>
    public void ShowCoinPickUpEffect(Vector3 pos)
    {
        Instantiate(sfx.sfxCoinPickUp, pos, Quaternion.identity);
    }
}
