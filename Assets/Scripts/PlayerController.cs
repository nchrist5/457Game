using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [Header("UI elements")]
    public Text healthText;
    public Text livesText;
    [Header("Movement Stuff")]
    public Rigidbody2D rb;
    public Vector2 movement;
    [Header("Player Stats")]
    public float speed = 5.0f;
    public float maxSpeed = 1f;
    public FloatValue healthMax;
    public PlayerProjectile myProjectile;
    public FloatValue shieldMax;
    private bool immunityOn;
    [Header("Assigned At Start")]
    public float health;
    public float shield;
    public static int lives = 3;
    public float damage;




    // Start is called before the first frame update
    private void Awake()
    {
        damage = myProjectile.damageMax.RuntimeValue;
        shield = shieldMax.RuntimeValue;
        health = healthMax.RuntimeValue;
        healthText.text = "Health: " + health;
        livesText = GameObject.Find("livesText").GetComponent<Text>();
        livesText.text = "Lives: " + lives;
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        immunityOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(0, Input.GetAxis("Vertical"));
        if (health <= 0)
        {
            //check if player has remaining lives
            if (lives > 0)
            {
                lives--;
                livesText.text = "Lives: " + lives;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            //if player has 0 lives 
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }

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
            pos[1] = -4.2f;
            transform.position = pos;
        }

        if (other.tag == "SouthWall")
        {
            pos[1] = 4.2f;
            transform.position = pos;
        }

        if (other.tag == "WestWall")
        {
            pos[0] = 8.2f;
            transform.position = pos;
        }

        if (other.tag == "EastWall")
        {
            pos[0] = -8.2f;
            transform.position = pos;
        }
        if (other.tag == "TutorialCheckpoint")
        {
            Destroy(other);
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
        //Not yet implemented. Commented out to remove error message on collisions.
        // if (go.CompareTag("HealthPickup"))
        // {
        //     print("Healed 10");
        //     health += 10f;
        //     healthText.text = "Health: " + health;
        //     Destroy(go);
        // }
    }
    IEnumerator damaged()
    {
        immunityOn = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(shield);
        GetComponent<SpriteRenderer>().color = Color.white;
        immunityOn = false;
    }
}
