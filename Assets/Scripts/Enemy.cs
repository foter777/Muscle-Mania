using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public static Action takeDamgage;
    public float health;
    public bool isObstacle;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);   
    }

    // Update is called once per frame
    void Update()
    {
        float relativeSpeed = Player.instance.speed / speed;
        Vector2 pos = transform.position;
        pos.x -= relativeSpeed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            takeDamgage?.Invoke();
        }
    }
}
