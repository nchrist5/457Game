using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public float laser_speed = 10f;
    private Rigidbody2D rb;
    private Rigidbody2D laserBody;
    private Vector2 movement;
    public GameObject LaserProjectile;
    public FloatValue healthMax;
    public float health;

    private void Awake()
    {
        health = healthMax.RuntimeValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }

        if (player.gameObject.activeSelf == true)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            
            if (Time.time > nextFire)
            {
                
                nextFire = Time.time + fireRate;
                GameObject Laser = Instantiate(LaserProjectile, transform.position, transform.rotation) as GameObject;
                laserBody = Laser.GetComponent<Rigidbody2D>();
                laserBody.AddForce(direction * laser_speed, ForceMode2D.Impulse);
            }
            
        }
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
        
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if (go.CompareTag("PlayerProjectile"))
        {
            health -= 10;
        }
    }
}
