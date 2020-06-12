using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class UI
{
    [Header("Text")]
    public Text txtCoinCount;

    [Header("Images")]
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    [Header("Controls")]
    public GameObject mobileUi;

    [Header("Menus")]
    public GameObject panelGameOver;
    public GameObject panelEndScreen;
    public GameObject panelPauseMenu;
}
