using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; // RSFB serializer
using System;
using System.Collections;

/// <summary>
/// Manage important game features such as, score restarting levels, load/ dave data, Update hub
/// </summary>
public class GameCtrl : MonoBehaviour
{

    public float restartDelay = 1f;
    public static GameCtrl instance;

    public GameData data;

    public UI ui;

    string dataFilePath;
    bool isPaused;

    BinaryFormatter bf;


    public void ShowEndScreen(GameObject player)
    {
        if (ui.mobileUi.gameObject.activeSelf)
            ui.mobileUi.gameObject.SetActive(false); // dissable controls to avoid interfirence with clicks
        ui.panelEndScreen.SetActive(true);
        // Disable player controls and movement.
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<PlayerCtrl>().enabled = false;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;

        bf = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/game.dat";
    }

    void Start()
    {
        HandleFirstBoot();
        UpdateHearts();
        isPaused = false;
    }


    void Update()
    {
        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    void UpdateHearts()
    {
        if (data.lives == 3)
        {
            ui.heart1.sprite = ui.fullHeart;
            ui.heart2.sprite = ui.fullHeart;
            ui.heart3.sprite = ui.fullHeart;
        }
        if (data.lives == 2)
        {
            ui.heart3.sprite = ui.emptyHeart;
        }
        if (data.lives == 1)
        {
            ui.heart2.sprite = ui.emptyHeart;
            ui.heart3.sprite = ui.emptyHeart;
        }
    }

    void CheckLives()
    {
        int updatedLives = data.lives;
        updatedLives -= 1;
        data.lives = updatedLives;

        if (data.lives > 0)
        {
            SaveData();
            Invoke("RestartLevelWithDelay", restartDelay);
        }
        else
        {
            data.lives = 3;
            SaveData();
            Invoke("GameOver", restartDelay);
        }
    }

    void HandleFirstBoot()
    {
        if (!data.isFristBoot) return;
        data.lives = 3;
        data.coinCount = 0;
        data.isFristBoot = false;
    }


    // Alternative use PlayerPrefs.
    public void SaveData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);   // Create file stream to get gameData.
        bf.Serialize(fs, data);      // Serialize data using file stream.
        fs.Close();
    }

    public void LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);   // Open file stream to get gameData.     
            data = (GameData)bf.Deserialize(fs);
            ui.txtCoinCount.text = " x " + data.coinCount;
            fs.Close();
        }
    }

    public void ResetData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        data.coinCount = 0; // manually reset coin.
        data.lives = 3;
        UpdateHearts();
        ui.txtCoinCount.text = " x 0";
        bf.Serialize(fs, data);
        fs.Close();
    }


    void OnEnable()
    {
        LoadData();
    }
    void OnDisable()
    {
        SaveData();
        Time.timeScale = 1; // Reset time in case of exit from pause
    }

    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
        CheckLives();
    }

    void RestartLevelWithDelay()
    {
        SceneManager.LoadScene("Level#1");
    }

    void GameOver()
    {
        ui.panelGameOver.SetActive(true);
    }

    public void UpdateCoinCount(int coins = 1)
    {
        data.coinCount += coins;
        ui.txtCoinCount.text = " x " + data.coinCount;
    }

    public void PlayerDiedAnimation(GameObject player)
    {

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 400f));      // push player to sky.

        player.transform.GetComponent<Collider2D>().enabled = false;        // dissable collider so it falls of camera.
        player.GetComponent<PlayerCtrl>().enabled = false; // disable controls

        foreach (Transform child in player.transform)
        {
            child.gameObject.SetActive(false);  // Dissable feet object (or any other colliders if I add them later)
        }

        Camera.main.GetComponent<CameraCtrl>().enabled = false; // dissable camera follow player 

        rb.velocity = Vector2.zero; // Set velocity to 0 so player doesnt fly away

        StartCoroutine("PlayerDieWithDelay", player);
    }

    IEnumerator PlayerDieWithDelay(GameObject player)
    {
        yield return new WaitForSeconds(1.5f); // wait for 1.5 seconds.
        PlayerDied(player);
    }

    public void EnemyGunedDown(Transform enemy)
    {
        UpdateCoinCount(10);
        Destroy(enemy.gameObject);
    }

    public void ShowPausePanel()
    {
        if (ui.mobileUi.gameObject.activeSelf)
            ui.mobileUi.gameObject.SetActive(false); // dissable controls to avoid interfirence with clicks
        ui.panelPauseMenu.SetActive(true);
        isPaused = true;
    }

    public void HidePausePanel()
    {
        if (!ui.mobileUi.gameObject.activeSelf)
            ui.mobileUi.gameObject.SetActive(true); // enable controls to avoid interfirence with clicks
        ui.panelPauseMenu.SetActive(false);
        isPaused = false;
    }


}


