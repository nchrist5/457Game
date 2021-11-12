using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSystem : MonoBehaviour
{
    [Header("Scene to transition to")]
    public string Scene;
    [Header("Number of waves wanted")]
    public Wave[] waves;

    public void Update()
    {

        foreach (Wave wave in waves)
        {
            wave.Update();

        }
        TestBattleOver();

    }
    private void TestBattleOver()
    {
        if (AreWavesOver())
        {
            // Battle is over!
            SceneManager.LoadScene(Scene);
        }

    }
    private bool AreWavesOver()
    {
        foreach (Wave wave in waves)
        {
            if (wave.IsWaveOver())
            {
                // Wave is over
            }
            else
            {
                // Wave not over
                return false;
            }
        }

        return true;
    }
    [System.Serializable]
    public class Wave
    {
        [Header("Add Enemies to wave")]
        public Enemy[] numEnemies;
        [Header("Time between each wave")]
        public float timer;
        public int thisWave;
        public int maxWave;

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
            foreach (Enemy enemy in numEnemies)
            {
                enemy.Spawn();
            }

        }
        public bool IsWaveOver()
        {
            if (timer < 0)
            {
                // Wave spawned
                foreach (Enemy enemy in numEnemies)
                {
                    if (enemy.health > 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                // Enemies haven't spawned yet
                return false;
            }
        }
    }
}
