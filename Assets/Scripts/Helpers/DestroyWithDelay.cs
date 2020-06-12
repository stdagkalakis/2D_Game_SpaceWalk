using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{

    public float delay = 1.5f;
    void Start()
    {
        Destroy(gameObject, delay);
    }


}
