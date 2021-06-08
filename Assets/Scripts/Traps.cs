using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    FMOD.Studio.EventInstance PlayerKilledSFX;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            PlayerKilledSFX = FMODUnity.RuntimeManager.CreateInstance("event:/Player Died");
            collision.gameObject.SetActive(false);
            HUDController.instance.GameOver();
            Time.timeScale = 0;
            PlayerKilledSFX.start();
        }
    }
}
