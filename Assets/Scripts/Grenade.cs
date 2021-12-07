using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float countDown;
    private bool hasExplosed;
    public FloatValue damageMax;
    public GameObject ExplosionEffect;
    public float Delay = 1f;
    public int GrenadeRadius = 5000;
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
            Rigidbody2D rigidbody = touchedObject.GetComponent<Rigidbody2D>();
            var target = touchedObject.gameObject.GetComponent<Enemy>();
            target.takeDamage(damageMax.RuntimeValue * 2 + 20);

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
