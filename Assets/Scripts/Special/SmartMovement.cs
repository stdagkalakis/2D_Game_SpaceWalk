using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartMovement : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed = 1f;


    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = rb.velocity;
        temp.x = speed;
        rb.velocity = temp;

        if (transform.position.x <= pos1.position.x)
            speed = (speed > 0) ? speed : (-1 * speed);
        if (transform.position.x >= pos2.position.x)
            speed = (speed < 0) ? speed : (-1 * speed);
        sr.flipX = (speed > 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
