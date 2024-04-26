using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStore : MonoBehaviour
{
    public GameObject store;
    private bool spawnStore = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.distance >= Player.instance.maxDistance && spawnStore)
        {
            Instantiate(store, transform.position, Quaternion.identity);
            spawnStore = false;
        }   
    }
}
