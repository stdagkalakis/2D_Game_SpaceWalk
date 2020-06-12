
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Control important aspects of the player such as movement, collision etc.
/// </summary>
public class PlayerCtrl : MonoBehaviour
{

    [Tooltip("Spped boost applied to player")]
    [Range(1f, 10f)]
    public int speedBoost = 5;

    public float jumpSpeed = 600f;
    public bool isGrounded, canDoubleJump;

    public LayerMask GroundMask;
    public float feetWidth = 0.6f;
    public float delayForDoubleJump = 0.2f;
    public Transform leftBulletSpawnPos, rightBulletSpawnPos;
    public GameObject leftBullet, rightBullet;
    public Transform feet;
    public bool sfxOn;
    public bool canFire;
    public bool isJumping = false;
    public GameObject garbageCtrl;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    bool mobileLeft, mobileRight;







    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        // isGrounded = Physics2D.OverlapCircle(feet.position, feetRadious, GroundMask);
        isGrounded = Physics2D.OverlapBox(feet.position, new Vector2(feetWidth, 0), 360.0f, GroundMask);
        float playerSpeed = Input.GetAxisRaw("Horizontal"); // 1 right, -1 left, 0 no arrow pressed
        playerSpeed *= speedBoost;
        if (playerSpeed != 0)
        {
            MoveHorizontal(playerSpeed);
        }
        else
        {
            StopMoving();
        }


        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire3"))
        {
            FireBullets();
        }

        if (mobileLeft)
            MoveHorizontal(-speedBoost);
        if (mobileRight)
            MoveHorizontal(speedBoost);
    }

    void FireBullets()
    {
        if (!canFire) return;
        AudioCtrl.instance.PlayerFire(gameObject.transform.position);
        if (sr.flipX)
            Instantiate(leftBullet, leftBulletSpawnPos.position, Quaternion.identity);
        else
            Instantiate(rightBullet, rightBulletSpawnPos.position, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(feet.position, new Vector2(feetWidth, 0));
    }
    void MoveHorizontal(float playerSpeed)
    {
        if (playerSpeed < 0) sr.flipX = true;
        else if (playerSpeed > 0) sr.flipX = false;
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);

        anim.SetInteger("State", 1);
    }


    void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (!isJumping) anim.SetInteger("State", 0);
    }

    void Jump()
    {
        if (isGrounded)
        {
            isJumping = false;
            rb.AddForce(new Vector2(0, jumpSpeed));
            anim.SetInteger("State", 2);
            AudioCtrl.instance.PlayerJump(gameObject.transform.position);
            Invoke("EnableDoubleJump", delayForDoubleJump);
        }

        if (canDoubleJump && !isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpSpeed));
            anim.SetInteger("State", 2);
            AudioCtrl.instance.PlayerJump(gameObject.transform.position);
            canDoubleJump = false;
        }


    }

    void EnableDoubleJump()
    {
        canDoubleJump = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Coin":
                GameCtrl.instance.UpdateCoinCount();
                AudioCtrl.instance.PickUpCoin(gameObject.transform.position);
                if (sfxOn)
                    SFXCtrl.instance.ShowCoinPickUpEffect(other.gameObject.transform.position);
                break;
            case "PowerUpBullet":
                canFire = true;
                AudioCtrl.instance.PickUpPowerUp(gameObject.transform.position);
                if (sfxOn)
                    SFXCtrl.instance.ShowBulletPickUpEffect(other.gameObject.transform.position);
                Destroy(other.gameObject);

                break;
            case "Water":
                garbageCtrl.SetActive(false);
                GameCtrl.instance.PlayerDied(gameObject);
                break;
            default:
                break;
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameCtrl.instance.PlayerDiedAnimation(gameObject);
        }
    }
    // Mobile Controller Functions
    public void MobileMoveRight()
    {
        mobileRight = true;
    }
    public void MobileMoveLeft()
    {
        mobileLeft = true;
    }

    public void MobileStop()
    {
        mobileRight = false;
        mobileLeft = false;
        StopMoving();
    }

    public void MobileFireBullets()
    {
        FireBullets();
    }

    public void MobileJump()
    {
        Jump();
    }
}
