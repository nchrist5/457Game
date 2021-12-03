using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Assign Manually")]
    public Transform player;
    private Rigidbody2D rb;
    private Rigidbody2D laserBody;
    private Vector2 movement;
    public GameObject LaserProjectile;
    public FloatValue healthMax;
    [Header("Initialized At Start")]
    public float health;
    [Header("Stats To Modify")]
    public float moveSpeed = 1f;
    public float fireRate = 0.5f;
    public float rotationSpeed = 100f;
    private float nextFire = 0.0f;
    public float laser_speed = 10f;
    [Header("Effects")]
    public GameObject deathEffect;
    private float deathEffectDelay = 1f;

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
    public virtual void Update()
    {
        if (health <= 0)
        {
            DeathEffect();
            Destroy(this.gameObject);
        }

        if (player.gameObject.activeSelf == true)
        {
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            direction.Normalize();
            movement = direction;

            if (Time.time > nextFire)
            {

                nextFire = Time.time + fireRate;
                GameObject Laser = Instantiate(LaserProjectile, transform.position, transform.rotation) as GameObject;
                laserBody = Laser.GetComponent<Rigidbody2D>();
                Vector2 laserDirection = transform.rotation.ToEulerAngles();
                Laser.GetComponent<Rigidbody2D>().velocity = transform.right * laser_speed;
            }

        }
    }
    public virtual void FixedUpdate()
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
            float damageTaken = other.GetComponent<PlayerProjectile>().damage;
            health -= damageTaken;
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }
    public void Spawn()
    {
        gameObject.SetActive(true);
    }
    public void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathEffectDelay);
        }
    }
}
