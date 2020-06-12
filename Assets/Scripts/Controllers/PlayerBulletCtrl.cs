using UnityEngine;

/// <summary>
/// Control the bullet and detect enemies and other objects.
/// </summary>
public class PlayerBulletCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        rb.velocity = velocity;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameCtrl.instance.EnemyGunedDown(other.gameObject.transform);
        }
        else if (!other.gameObject.CompareTag("Player"))    // Destroy bullet on contact
        {
            Destroy(gameObject);
        }
    }
}
