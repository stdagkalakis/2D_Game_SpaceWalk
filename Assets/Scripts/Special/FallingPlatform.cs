using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    Rigidbody2D rb;

    public float droppingDelay = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Invoke("StartDropping", droppingDelay);
    }

    void StartDropping()
    {
        rb.isKinematic = false;
    }
}
