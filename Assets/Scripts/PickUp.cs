using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickUp : MonoBehaviour
{
    public static Action pickUpItem;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Player.instance.protein += 1;
            pickUpItem?.Invoke();
            AudioManager.instance.PlayEffect(4);
            Destroy(gameObject);
        }
    }
}
