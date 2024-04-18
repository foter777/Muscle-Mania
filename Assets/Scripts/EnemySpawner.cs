using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnCooldown;
    private float spawnTimer;
    public List<Enemy> enemies;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = spawnCooldown;
            Instantiate(enemies[Random.Range(0,enemies.Count)],transform.position, Quaternion.identity);
        }
    }
}
