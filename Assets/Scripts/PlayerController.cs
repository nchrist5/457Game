using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header ("UI elements")]
    public Text healthText;
    [Header("Movement Stuff")]
    public Rigidbody2D rb;
    public Vector2 movement;
    [Header("Player Stats")]
    public float speed = 5.0f;
    public float maxSpeed = 1f;
    public FloatValue healthMax;
    [Header("Shield once hit")]
    public float immunity;
    private bool immunityOn;
    [Header("Assigned At Start")]
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
        immunityOn = false;
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

        //This block of code checks if a enemy laser is hitting the ship
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if (go.CompareTag("EnemyProjectile") || go.CompareTag("Enemy"))
        {
            if (!immunityOn)
            {
                StartCoroutine(damaged());
                float damageTaken = other.GetComponent<EnemyProjectile>().damage;
                health -= damageTaken;
                healthText.text = "Health: " + health;
            }
        }
    }
    IEnumerator damaged()
    {
        immunityOn = true;
        yield return new WaitForSeconds(immunity);
        immunityOn = false;
    }
}
