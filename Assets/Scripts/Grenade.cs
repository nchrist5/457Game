using System.Linq;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float countDown;
    private bool hasExplosed;

    public GameObject ExplosionEffect;
    public float Delay = 1f;
    public int GrenadeRadius = 5000;
    public float Damage = 60f;
    private float explosionEffectDelay = 1f;

    void Start()
    {
        countDown = Delay;

    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0f && !hasExplosed)
        {
            Explode();
            hasExplosed = true;
        }
    }

    private void Explode()
    {
        
        GameObject effect = Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Collider2D[] touchedObjects = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), GrenadeRadius).Where(x => x.tag == "Enemy").ToArray();

        foreach (Collider2D touchedObject in touchedObjects)
        {
            Debug.Log("Collision");
            Enemy enemyScript = touchedObject.gameObject.GetComponent<Enemy>();
            Rigidbody2D rigidbody = touchedObject.GetComponent<Rigidbody2D>();
            var target = touchedObject.gameObject.GetComponent<Enemy>();
            target.takeDamage(Damage);

        }
        Destroy(gameObject);
        Destroy(effect, explosionEffectDelay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if (!(go.CompareTag("Player") || go.CompareTag("EnemyProjectile") || go.CompareTag("PlayerProjectile")))
        {
            countDown = 0f;
        }

    }


}
