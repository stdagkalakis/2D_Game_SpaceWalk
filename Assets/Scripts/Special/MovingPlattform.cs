using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlattform : MonoBehaviour
{

    public Transform pos1, pos2;
    public float speed = 1f;
    public Transform startPos;

    Vector3 nextPosition;
    void Start()
    {
        nextPosition = startPos.position;
    }


    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPosition = pos2.position;
        }

        if (transform.position == pos2.position)
        {
            nextPosition = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);

    }

}
