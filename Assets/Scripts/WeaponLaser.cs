using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : MonoBehaviour
{
    public Rigidbody2D rb;
    public float laser_speed = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = GameObject.FindGameObjectWithTag("Crosshair").transform.position * laser_speed;
    }

    //destroy projectile on collide or after 1.0 seconds
    private void OnTriggerEnter2D(Collider2D colide)
    {
        Destroy(this.gameObject, 1.0f);
    }
}
