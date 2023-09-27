using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleController : MonoBehaviour
{

    [SerializeField] private int ammoNumber = 1;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float maxReloadTime;

    private float reloadTime;
    

    private Vector2 ammo2Right;
    private Vector2 ammo2Left;

    [SerializeField] private AudioClip shootingClip;
    [SerializeField] private AudioClip pickupClip1;
    [SerializeField] private AudioClip pickupClip2;

    void Start()
    {
        GameManager.Instance.ammoNumberGlobal = ammoNumber;
    }

    
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        reloadTime += Time.deltaTime;
        if (reloadTime >= maxReloadTime && Input.GetButtonDown("Fire1"))
        {
            if (ammoNumber == 1)
            {
                Instantiate(projectile, this.transform.position, this.transform.rotation);
            }
            else if (ammoNumber == 2)
            {
                ammo2Right = transform.position + new Vector3(0.3f, 0f);
                ammo2Left = transform.position + new Vector3(-0.3f, 0f);

                Instantiate(projectile, ammo2Right, this.transform.rotation);
                Instantiate(projectile, ammo2Left, this.transform.rotation);
            }
            else if(ammoNumber == 3)
            {
                ammo2Right = transform.position + new Vector3(0.4f, 0f);
                ammo2Left = transform.position + new Vector3(-0.4f, 0f);

                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, ammo2Right, this.transform.rotation);
                Instantiate(projectile, ammo2Left, this.transform.rotation);
            }

            try
            {
                SoundManager.Instance.PlaySound(shootingClip);
            }
            catch (Exception)
            {
                Debug.Log("[" + gameObject.name + "] EFFECT SOURCE NOT FOUND");
            }
            reloadTime = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "X2AMMO")
        {
            ammoNumber = 2;
            GameManager.Instance.ammoNumberGlobal = ammoNumber;
            Destroy(collision.gameObject);
            SoundManager.Instance.PlaySound(pickupClip1);
        }
        if(collision.gameObject.tag == "X3AMMO")
        {
            ammoNumber = 3;
            GameManager.Instance.ammoNumberGlobal = ammoNumber;
            Destroy(collision.gameObject);
            SoundManager.Instance.PlaySound(pickupClip2);
        }

    }
}
