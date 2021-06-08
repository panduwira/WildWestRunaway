using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject bulletPrefab;
    public int Ammo;
    private Animator myAnimator;
    FMOD.Studio.EventInstance ReloadSFX;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        ReloadSFX = FMODUnity.RuntimeManager.CreateInstance("event:/Reload");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && Ammo > 0)
        {
            Shoot();
            Ammo--;
            myAnimator.Play("shoot");
            HUDController.instance.SetHUDAmmo(Ammo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AmmoBox"){
            ReloadSFX.start();
            Ammo = 6;
            collision.gameObject.SetActive(false);
            HUDController.instance.SetHUDAmmo(Ammo);
        }
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
    }
}
