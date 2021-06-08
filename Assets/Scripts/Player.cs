using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public static Player instance;
    bool isOnGround;
    private Rigidbody2D rb;
    private Animator animator;
    FMOD.Studio.EventInstance BGM;
    FMOD.Studio.EventInstance JumpSFX;

    void Start()
    {
        instance = this;
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isOnGround = true;
        BGM = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
        JumpSFX =FMODUnity.RuntimeManager.CreateInstance("event:/Jump");
        BGM.start();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isOnGround = false;
            animator.Play("jump");
            JumpSFX.start();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isOnGround = true;
            animator.Play("run");
        }
        else if (collision.gameObject.name == "Horse")
        {
            Time.timeScale = 0;
            HUDController.instance.YouWin();
            BGM.release();
        }
    }
    public void bgmStop()
    {
        BGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        BGM.release();
    }

}
