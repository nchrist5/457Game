using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialCheckpoint : MonoBehaviour
{
    public Enemy enemy;
    

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
        enemy.Spawn();
    }
}
