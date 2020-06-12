using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Router : MonoBehaviour
{
    public void ShowPauseMenu()
    {
        GameCtrl.instance.ShowPausePanel();
    }
    public void HidePauseMenu()
    {
        GameCtrl.instance.HidePausePanel();
    }

    public void ToggleSound()
    {
        AudioCtrl.instance.ToggleSounds();
    }

    public void ToggleBGMusic()
    {
        AudioCtrl.instance.ToggleBGMusic();
    }
}
