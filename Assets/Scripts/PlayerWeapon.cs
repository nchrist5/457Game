using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform playerFirePoint;
    public GameObject LaserProjectile;

    public float laser_speed = 15f;
    public float playerFireRate = 0.2f;
    private float playerNextFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //hold (or click) left mouse to fire
        if ((Input.GetButton("Fire1")) && (Time.time > playerNextFire))
        {
            playerNextFire = Time.time + playerFireRate;
            Shoot();
        }
    }

    //shooting method for player
    //playerfirepoint is child of SpaceShip, dictates where projectile spawns
    void Shoot()
    {
        GameObject laser = Instantiate(LaserProjectile, playerFirePoint.position, playerFirePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
    }
}
