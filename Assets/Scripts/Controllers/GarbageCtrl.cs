using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Catch the player when he falls of screen.
/// </summary>
public class GarbageCtrl : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameCtrl.instance.PlayerDied(other.gameObject);
        else
            Destroy(other.gameObject);
    }
}
