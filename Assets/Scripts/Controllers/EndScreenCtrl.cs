using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenCtrl : MonoBehaviour
{
    public Text txtCoinText;


    void Start()
    {
        txtCoinText.text = " x " + GameCtrl.instance.data.coinCount;
    }
}
