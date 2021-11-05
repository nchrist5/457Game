using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform playerFirePoint;
    public GameObject LaserProjectile;

    public float laser_speed = 15f;

    // Update is called once per frame
    void Update()
    {
        //fire1 bound to left click
        if (Input.GetButtonDown("Fire1"))
        {
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
