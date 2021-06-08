using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeDuration = 5f;
    public Rigidbody2D rb;
    private float lifeTimer;
    FMOD.Studio.EventInstance GunnerKilledSFX;
    FMOD.Studio.EventInstance WolfKilledSFX;
    FMOD.Studio.EventInstance PlayerKilledSFX;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        GunnerKilledSFX = FMODUnity.RuntimeManager.CreateInstance("event:/Gunner Killed");
        WolfKilledSFX = FMODUnity.RuntimeManager.CreateInstance("event:/Wolf Killed");
        PlayerKilledSFX = FMODUnity.RuntimeManager.CreateInstance("event:/Player Died");
    }

    void OnEnable()
    {
        lifeTimer = lifeDuration;
    }

    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if (collision.tag == "Enemy")
        { 
            collision.gameObject.SetActive(false);
            GunnerKilledSFX.start();
        }
        else if (collision.tag == "Wolf")
        {
            collision.gameObject.SetActive(false);
            WolfKilledSFX.start();
        }
        else if (collision.name == "Player")
        {
            collision.gameObject.SetActive(false);
            Time.timeScale = 0;
            HUDController.instance.GameOver();
            PlayerKilledSFX.start();
        }
    }

}
