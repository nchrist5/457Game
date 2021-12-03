using System.Linq;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float countDown;
    private bool hasExplosed;

    public GameObject ExplosionEffect;
    public float Delay = 3f;
    public float GrenadeRadius = 5000f;
    public float ExplosionForce = 7000f;
    public float Damage = 60f;

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
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Collider[] touchedObjects = Physics.OverlapSphere(transform.position, GrenadeRadius).Where(x => x.tag == "Enemy").ToArray();

        foreach (Collider touchedObject in touchedObjects)
        {
            Rigidbody rigidbody = touchedObject.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(ExplosionForce, transform.position, GrenadeRadius);
            }

            var target = touchedObject.gameObject.GetComponent<Enemy>();
            target.takeDamage(Damage);

        }
        Destroy(gameObject);
    }
}
