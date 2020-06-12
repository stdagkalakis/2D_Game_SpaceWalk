using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartLevel(string sceneName)
    {
        GameCtrl.instance.ResetData();
        SceneManager.LoadScene(sceneName);
    }
}
