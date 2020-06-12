using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Add the coins on the end screen.
/// </summary>
public class EndScreenCtrl : MonoBehaviour
{
    public Text txtCoinText;
    void Start()
    {
        txtCoinText.text = " x " + GameCtrl.instance.data.coinCount;
    }
}
