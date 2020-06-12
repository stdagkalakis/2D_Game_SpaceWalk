
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
/// <summary>
/// Audio controller responsible for handling Audio (such as bg music) player sounds (pick up, jump etc)
/// </summary>

public class AudioCtrl : MonoBehaviour
{

    public static AudioCtrl instance;
    public PlayerAudio playerAudio;

    public Transform player;

    public GameObject BGMusic;
    public bool muteBG;

    public bool mute;
    void Start()
    {
        if (instance == null)
            instance = this;

        BGMusic.SetActive(!muteBG);
    }


    public void PlayerJump(Vector3 playerPos)
    {
        if (!mute)
        {
            AudioSource.PlayClipAtPoint(playerAudio.playerJump, playerPos);
        }
    }

    public void PlayerFire(Vector3 playerPos)
    {
        if (!mute)
        {
            AudioSource.PlayClipAtPoint(playerAudio.fireBullet, playerPos);
        }
    }

    public void PickUpCoin(Vector3 playerPos)
    {
        if (!mute)
        {
            AudioSource.PlayClipAtPoint(playerAudio.pickUpCoin, playerPos);
        }

    }

    public void PickUpPowerUp(Vector3 playerPos)
    {
        if (!mute)
        {
            AudioSource.PlayClipAtPoint(playerAudio.powerUp, playerPos);
        }
    }

    public void ToggleBGMusic()
    {
        BGMusic.SetActive(!BGMusic.gameObject.activeSelf);
    }

    public void ToggleSounds()
    {
        mute = !mute;
    }
}
