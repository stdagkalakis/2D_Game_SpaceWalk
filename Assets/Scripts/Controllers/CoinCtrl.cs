using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (startFlying)
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        // transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 40f, transform.position.y), speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
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
