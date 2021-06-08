using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Ammo;
    public Image gameOver;
    public Image youWin;
    public static HUDController instance;

    void Start()
    {
        instance = this;
    }

    public void SetHUDAmmo(int value = 0)
    {
        Ammo.text = "Ammo x " + value.ToString();
    }

    public void GameOver()
    {
        gameOver.transform.gameObject.SetActive(true);      
        Ammo.text = ("");
    }
    public void YouWin()
    {
        youWin.transform.gameObject.SetActive(true);
        Ammo.text = ("");
    }
}
