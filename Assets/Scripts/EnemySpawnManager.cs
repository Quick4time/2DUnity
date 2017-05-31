using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {
    public float spawnTime = 5.0f;
    // The amount of time between each spawn.
    public float spawnDelay = 3.0f;
    // The amount of time before spawning starts.
    public GameObject[] enemies;
    // Array of enemy prefab

    private void Start()
    {
        StartCoroutine(StartSpawn());
        //InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        whtr:
        while (true)
        { 
            Spawn();
            yield return new WaitForSeconds(spawnTime);
            goto whtr;
        }
    }
    void Spawn()
    {
        // Instantiate a random enemy.
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
    }
}
