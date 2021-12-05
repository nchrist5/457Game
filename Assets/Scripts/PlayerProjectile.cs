using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public FloatValue damageMax;
    public float damage;
    public void Awake()
    {
        if (PlayerWeapon.railgun == true)
        {
            damage = (damageMax.RuntimeValue + 10) * 2;
        }

        else {
            damage = damageMax.RuntimeValue;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if (!(go.CompareTag("Player") || go.CompareTag("EnemyProjectile") || go.CompareTag("PlayerProjectile")))
        {
            Destroy(this.gameObject);
        }
        
    }
}
