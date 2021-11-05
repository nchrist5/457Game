using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public float maxSpeed = 1f;
    public FloatValue healthMax;
    public float health;


    // Start is called before the first frame update
    private void Awake()
    {
        health = healthMax.RuntimeValue;
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(0, Input.GetAxis("Vertical"));
        if (health <= 0)
            this.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        movePlayer(movement);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void movePlayer(Vector2 direction) 
    {
        rb.AddRelativeForce(direction * speed);
    }

    public void OnCollisionEnter2D(Collision2D other) //For collisions, can be used to detroy the player ship via running into ships or projectiles
    {
        health -= 10;
    }

    //side-to-side teleport & top-to-bottom teleport
    //checks tag of walls and sets player position to opposite wall upon trigger detection
    public void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 pos = transform.position;

        if (other.tag == "NorthWall")
        {
            pos[1] = -4.5f;
            transform.position = pos;
        }

        if (other.tag == "SouthWall")
        {
            pos[1] = 4.5f;
            transform.position = pos;
        }

        if (other.tag == "WestWall")
        {
            pos[0] = 8.4f;
            transform.position = pos;
        }

        if (other.tag == "EastWall")
        {
            pos[0] = -8.4f;
            transform.position = pos;
        }
    }

}
