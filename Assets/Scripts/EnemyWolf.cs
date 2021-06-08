using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWolf : MonoBehaviour
{
    public float moveSpeed;
    public float aggroRange;
    public Transform player;
    private Rigidbody2D myRigidbody;
    FMOD.Studio.EventInstance PlayerKilledSFX;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        PlayerKilledSFX = FMODUnity.RuntimeManager.CreateInstance("event:/Player Died");
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < aggroRange)
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, myRigidbody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") 
        {
            PlayerKilledSFX.start();
            collision.gameObject.SetActive(false);
            HUDController.instance.GameOver();
            Time.timeScale = 0;
        }
    }


}
