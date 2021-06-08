using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : MonoBehaviour
{
    public Transform Firepoint;
    public Transform player;
    public GameObject bulletPrefab;
    private float aggroRange = 4;
    public float fireRateDelay;
    private float nextFire;
    private Rigidbody2D rb2d;
    private Animator myAnimator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        nextFire = Time.time;
        myAnimator.Play("enemyIdle");
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position); 
        if(distanceToPlayer < aggroRange)
        { 
            Shoot();
            return;
        }
    }
    void Shoot()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
            myAnimator.Play("enemyShoot");
            nextFire = Time.time + fireRateDelay;
        }
    }

}
