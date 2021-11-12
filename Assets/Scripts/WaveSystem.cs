using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSystem : MonoBehaviour
{
    [Header("Scene to transition to")]
    public string Scene;
    [Header("Number of waves wanted")]
    [SerializeField] private List<Wave> waves = new List<Wave>();
    [SerializeField] private float waveTotal;

    public void Update()
    {
        waveTotal = waves.Count;
        foreach (Wave wave in waves)
        {
            wave.Update();
        }

    }

    [System.Serializable]
    private class Wave
    {
        [Header("Add Enemies to wave")]
        public Enemy[] numEnemies;
        [Header("Time between each wave")]
        public float timer;
        public float currentWave;
         

        public void Update()
        {
            
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    SpawnEnemies();
                }
            }
        }



        public void SpawnEnemies()
        {
            foreach(Enemy enemy in numEnemies)
            {
                enemy.Spawn();
            }
        }
    }
}
