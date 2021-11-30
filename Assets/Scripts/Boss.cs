using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private Rigidbody2D body;
    private Rigidbody2D laserBody;
    private float x;
    private float minDist;
    private float maxDist;
    private float maxY;
    private float nextFire = 0.0f;
    private Vector3 localScale;
    void Start()
    {
        localScale = transform.localScale;
        body = GetComponent<Rigidbody2D>();
        x = -1f;
        minDist = -5.9f;
        maxDist = 5.9f;
        maxY = 0f;

        moveSpeed = 3f;
    }
    public override void Update()
    {
        if (health <= 0)
        {
            DeathEffect();
            Destroy(this.gameObject);
        }
        switch (x)
        {
            case -1:
                // Moving Left
                if (transform.position.x > minDist)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    x = 1;
                }
                break;
            case 1:
                //Moving Right
                if (transform.position.x < maxDist)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    x = -1;
                }
                break;
        }
        if (Time.time > nextFire)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            nextFire = Time.time + fireRate;
            Vector3 shot = new Vector3(transform.position.x, 1);
            GameObject Laser = Instantiate(LaserProjectile, shot, transform.rotation) as GameObject;
            laserBody = Laser.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(0, -4);
            laserBody.AddForce(force * laser_speed);
            //laserBody.AddForce(direction * laser_speed, ForceMode2D.Impulse);
        }

    }


    public override void FixedUpdate()
    {
        if (x > 5)
            x = -1f;
        body.velocity = new Vector2(x * moveSpeed, maxY);
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if (go.CompareTag("PlayerProjectile"))
        {
            float damageTaken = other.GetComponent<PlayerProjectile>().damage;
            health -= damageTaken;
        }
    }
}
