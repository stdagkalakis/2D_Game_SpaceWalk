using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mobile player controls, enable character use from mobile UI controls
/// </summary>
public class MobileUICtrl : MonoBehaviour
{


    public GameObject player;

    PlayerCtrl playerCtrl;

    void Start()
    {
        playerCtrl = player.GetComponent<PlayerCtrl>();
    }

    public void MobileMoveLeft()
    {
        playerCtrl.MobileMoveLeft();
    }

    public void MobileMoveRight()
    {
        playerCtrl.MobileMoveRight();
    }

    public void MobileStop()
    {
        playerCtrl.MobileStop();
    }

    public void MobileFireBullets()
    {
        playerCtrl.MobileFireBullets();
    }

    public void MobileJump()
    {
        playerCtrl.MobileJump();
    }
}
