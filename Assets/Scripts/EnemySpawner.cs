using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float maxSpawnCooldown;
    public float minSpawnCooldown;
    private float spawnTimer;
    public List<Enemy> enemies;
    public List<PickUp> pickUps;
    public float enemySpawnChance;
    public float spawnBuffer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnBuffer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = Random.Range(minSpawnCooldown,maxSpawnCooldown);
            if (Random.value < enemySpawnChance)
            {
                Instantiate(enemies[Random.Range(0,enemies.Count)],transform.position, Quaternion.identity);
                Vector2 newPos = transform.position;
                newPos.y += 2f;
                Instantiate(pickUps[0],newPos, Quaternion.identity);
            }
            else
            {
                Instantiate(pickUps[0],transform.position, Quaternion.identity);
            }
            //Instantiate(enemies[Random.Range(0,enemies.Count)],transform.position, Quaternion.identity);
            
        }
    }
}
