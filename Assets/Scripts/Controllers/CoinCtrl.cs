using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls coin behaviour, pick up on collision.
/// </summary>
public class CoinCtrl : MonoBehaviour
{
    public enum CoinFX
    {
        Vanish,
        Fly
    }
    public CoinFX coinFX;
    public float speed = 1f;
    public float destroyDelay = 10f;

    bool startFlying = false;

    Vector3 endPos;

    void Update()
    {
        // fly upwards
        if (startFlying)
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            // Pick up effect, vanish of Fly upwards
            if (coinFX == CoinFX.Vanish)
                Destroy(gameObject);
            else if (coinFX == CoinFX.Fly)
            {
                startFlying = true;
                endPos = new Vector3(transform.position.x, transform.position.y + 100f, transform.position.z);
                Destroy(gameObject, destroyDelay);
            }
        }
    }


}
