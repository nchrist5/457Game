using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialFinish : MonoBehaviour
{
    public Enemy enemy;
    public int shipHasSpawned = 0;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Enemy") != null)
        {
            shipHasSpawned = 1;
        }
        if (enemy.health <= 0 && shipHasSpawned == 1)
        {
            SceneManager.LoadScene("Home");
        }
    }
}
