using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform playerFirePoint;
    public GameObject LaserProjectile;
    public GameObject shotgunProjectile;
    public GameObject grenadeProjectile;
    public float laser_speed = 15f;
    public float playerFireRate = 0.2f;
    public float throwForce = 1f;
    private float playerNextFire = 0.0f;

    public static bool defaultWeapon = false;
    public static bool upgrade = false;
    public static bool railgun = false;
    public static bool shotgun = false;
    public static bool grenade = true;

    // Update is called once per frame
    void Update()
    {
        //hold (or click) left mouse to fire
        if ((Input.GetButton("Fire1")) && (Time.time > playerNextFire))
        {
            playerNextFire = Time.time + playerFireRate;

            //check which weapon is equipped
            if (upgrade == true)
            {
                ShootUpgrade();
            }
            else if (railgun == true)
            {

            }
            else if (shotgun == true)
            {
                ShootShotgun();
            }
            else if (grenade == true)
            {
                GameObject grenadeObject = Instantiate(grenadeProjectile, playerFirePoint.transform.position, playerFirePoint.transform.rotation);
                Rigidbody2D grenadeRigidbody = grenadeObject.GetComponent<Rigidbody2D>();
                grenadeRigidbody.AddForce(playerFirePoint.up * throwForce, ForceMode2D.Impulse);
            }
            else
            {
                Shoot();
            }   
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

    //shooting method for upgraded laser
    void ShootUpgrade()
    {
        GameObject laser1 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(-0.3f, 0.0f, 0.0f), playerFirePoint.rotation);
        GameObject laser2 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.3f, 0.0f, 0.0f), playerFirePoint.rotation);

        Rigidbody2D rb1 = laser1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = laser2.GetComponent<Rigidbody2D>();
        rb1.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        rb2.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
    }
    void ShootShotgun()
    {
        LaserProjectile = shotgunProjectile;
        GameObject laser0 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.0f, 0.0f, 0.0f), playerFirePoint.rotation);
        GameObject laser1 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(-0.3f, 0.0f, 0.0f), playerFirePoint.rotation);
        GameObject laser2 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.3f, 0.0f, 0.0f), playerFirePoint.rotation);
        GameObject laser3 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(-0.6f, 0.0f, 0.0f), playerFirePoint.rotation);
        GameObject laser4 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.6f, 0.0f, 0.0f), playerFirePoint.rotation);
        Rigidbody2D rb0 = laser0.GetComponent<Rigidbody2D>();
        Rigidbody2D rb1 = laser1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = laser2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = laser4.GetComponent<Rigidbody2D>();
        Rigidbody2D rb4 = laser3.GetComponent<Rigidbody2D>();
        rb0.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        rb1.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        rb2.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        rb3.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        rb4.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        Destroy(laser0, 0.15f);
        Destroy(laser1, 0.15f);
        Destroy(laser2, 0.15f);
        Destroy(laser3, 0.15f);
        Destroy(laser4, 0.15f);
    }
}
