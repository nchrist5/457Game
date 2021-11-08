using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if (!(go.CompareTag("Enemy") || go.CompareTag("EnemyProjectile") || go.CompareTag("PlayerProjectile")))
        {
            Destroy(this.gameObject);
        }
        
    }
}
