using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour
{

    public GameObject player;
    PlayerCtrl playerCtrl;


    void Start()
    {
        playerCtrl = gameObject.transform.parent.GetComponent<PlayerCtrl>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            playerCtrl.isJumping = false;
        }

        if (other.gameObject.CompareTag("Platform"))
        {

            playerCtrl.isJumping = false;
            player.transform.parent = other.gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }
}
