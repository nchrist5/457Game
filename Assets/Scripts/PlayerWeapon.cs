using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform playerFirePoint;
    public GameObject LaserProjectile;

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
        Instantiate(LaserProjectile, playerFirePoint.position, playerFirePoint.rotation);
    }
}
