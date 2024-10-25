using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    [SerializeField] float playerBulletSpeed = 10f;
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject playerFlair;
    [SerializeField] GameObject playerGun;
    public bool canShoot = true;
    private int flairOut = 0;
    void Start()
    {



    }

    void OnFire()
    {
    
    GameObject bullet = Instantiate(playerBullet, playerGun.transform.position, playerGun.transform.rotation);
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(playerGun.transform.up * playerBulletSpeed, ForceMode2D.Impulse);
    }

    void OnFlair()
    {
        if (flairOut <= 1)
        {
            GameObject flair = Instantiate(playerFlair, playerGun.transform.position, playerGun.transform.rotation);
            Rigidbody2D rb = flair.GetComponent<Rigidbody2D>();
            rb.AddForce(playerGun.transform.up * playerBulletSpeed, ForceMode2D.Impulse);
            flairOut += 1;
        }
    }


    void Update()
    {
        


    }
}
