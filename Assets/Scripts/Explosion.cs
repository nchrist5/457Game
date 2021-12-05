using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Collider2D myCollider;
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(true);
            myCollider.enabled = !myCollider.enabled;
        }
    }
}
