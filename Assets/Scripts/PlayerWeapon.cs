using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform playerFirePoint;
    public GameObject LaserProjectile;
    public GameObject shotgunProjectile;
    public GameObject grenadeProjectile;
    public GameObject railgunProjectile;

    public float laser_speed = 15f;
    public float playerFireRate = 0.2f;
    public float throwForce = 1f;
    public float railgunFireRate = 1.0f;
    public float grenadeFireRate = 0.5f;

    private float playerNextFire = 0.0f;

    public static bool defaultWeapon = true;
    public static bool upgrade = false;
    public static bool railgun = false;
    public static bool shotgun = false;
    public static bool grenade = false;

    //shotgun gameobjects; declared to make unity happy
    GameObject sg0;
    GameObject sg1;
    GameObject sg2;
    GameObject sg3;
    GameObject sg4;

    //upgraded-weapon gameobjects; declared to make unity happy
    GameObject laser1;
    GameObject laser2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > playerNextFire)
            {
                if (defaultWeapon == true)
                {
                    playerNextFire = Time.time + playerFireRate;
                    Shoot();
                } else if (upgrade == true)
                {
                    playerNextFire = Time.time + playerFireRate;
                    ShootUpgrade();
                }
                else if (shotgun == true)
                {
                    playerNextFire = Time.time + playerFireRate;
                    ShootShotgun();
                }
                else if (railgun == true)
                {
                    playerNextFire = Time.time + railgunFireRate;
                    ShootRailgun();
                }
                else if (grenade == true)
                {
                    playerNextFire = Time.time + grenadeFireRate;
                    ShootGrenade();
                }
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
        //if firing in UP/DOWN alignment
        if (((Pivot.shipRot > -60) & (Pivot.shipRot < 60)) | ((Pivot.shipRot < -120) & (Pivot.shipRot > -240)))
        {
        laser1 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(-0.3f, 0.0f, 0.0f), playerFirePoint.rotation);
        laser2 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.3f, 0.0f, 0.0f), playerFirePoint.rotation);
        } 
        //if firing in LEFT/RIGHT alignment
        else if (((Pivot.shipRot > 60) | (Pivot.shipRot < -240)) | ((Pivot.shipRot > -120) & (Pivot.shipRot < -60)))
        {
            laser1 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.0f, -0.3f, 0.0f), playerFirePoint.rotation);
            laser2 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.0f, 0.3f, 0.0f), playerFirePoint.rotation);
        }

        Rigidbody2D rb1 = laser1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = laser2.GetComponent<Rigidbody2D>();
        rb1.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        rb2.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
    }


    void ShootShotgun()
    {
        LaserProjectile = shotgunProjectile;

        //if firing in UP/DOWN alignment
        if (((Pivot.shipRot > -60) & (Pivot.shipRot < 60)) | ((Pivot.shipRot < -120) & (Pivot.shipRot > -240)))
        {
            sg0 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.0f, 0.0f, 0.0f), playerFirePoint.rotation);
            sg1 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(-0.3f, 0.0f, 0.0f), playerFirePoint.rotation);
            sg2 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.3f, 0.0f, 0.0f), playerFirePoint.rotation);
            sg3 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(-0.6f, 0.0f, 0.0f), playerFirePoint.rotation);
            sg4 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.6f, 0.0f, 0.0f), playerFirePoint.rotation);
        } 
        //if firing in LEFT/RIGHT alignment
        else if (((Pivot.shipRot > 60) | (Pivot.shipRot < -240)) | ((Pivot.shipRot > -120) & (Pivot.shipRot < -60)))
        {
            sg0 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.0f, 0.0f, 0.0f), playerFirePoint.rotation);
            sg1 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.0f, 0.3f, 0.0f), playerFirePoint.rotation);
            sg2 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.0f, -0.3f, 0.0f), playerFirePoint.rotation);
            sg3 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.0f, 0.6f, 0.0f), playerFirePoint.rotation);
            sg4 = Instantiate(LaserProjectile, playerFirePoint.position + new Vector3(0.0f, -0.6f, 0.0f), playerFirePoint.rotation);
        }
        


        Rigidbody2D rb0 = sg0.GetComponent<Rigidbody2D>();
        Rigidbody2D rb1 = sg1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = sg2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = sg4.GetComponent<Rigidbody2D>();
        Rigidbody2D rb4 = sg3.GetComponent<Rigidbody2D>();
        rb0.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        rb1.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        rb2.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        rb3.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        rb4.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
        Destroy(sg0, 0.15f);
        Destroy(sg1, 0.15f);
        Destroy(sg2, 0.15f);
        Destroy(sg3, 0.15f);
        Destroy(sg4, 0.15f);
    }


    void ShootRailgun()
    {
        GameObject laser = Instantiate(railgunProjectile, playerFirePoint.position, playerFirePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(playerFirePoint.up * laser_speed, ForceMode2D.Impulse);
    }


    void ShootGrenade()
    {
        GameObject grenadeObject = Instantiate(grenadeProjectile, playerFirePoint.transform.position, playerFirePoint.transform.rotation);
        Rigidbody2D grenadeRigidbody = grenadeObject.GetComponent<Rigidbody2D>();
        grenadeRigidbody.AddForce(playerFirePoint.up * throwForce, ForceMode2D.Impulse);
    }
}
