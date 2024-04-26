using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public static Action takeDamage;
    public float health;
    public bool isObstacle;
    public BoxCollider2D boxCollider2D;
    Vector3 randomDirection;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);   
        randomDirection= UnityEngine.Random.insideUnitSphere.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            Move();
        }

        else
        {
            
            MoveInDirection(randomDirection);
        }
    }

    private void Move()
    {
        float relativeSpeed = Player.instance.speed / speed;
        Vector2 pos = transform.position;
        pos.x -= relativeSpeed * Time.deltaTime;
        transform.position = pos;
    }

    void MoveInDirection(Vector3 direction)
    {
        // Move the object in the specified direction
        boxCollider2D.enabled = false;
        transform.Translate(direction * speed * 10 * Time.deltaTime);
        //AudioManager.instance.PlayEffect(3);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            if (!Player.instance.proteinMode)
            {
                takeDamage?.Invoke();
            }
            else
            {
                Damage(health);
            }
            AudioManager.instance.PlayEffect(0);
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
    }
}
