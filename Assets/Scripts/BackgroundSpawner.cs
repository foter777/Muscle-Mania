using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public float maxSpawnCooldown;
    public float minSpawnCooldown;
    private float spawnTimer;
    public List<GameObject> buildings;
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
            Instantiate(buildings[Random.Range(0, buildings.Count)],transform.position,Quaternion.identity);

        }
    }
}
