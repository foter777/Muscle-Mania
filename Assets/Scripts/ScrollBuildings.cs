using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBuildings : MonoBehaviour
{
    public float depth;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);   
    }

    // Update is called once per frame
    void Update()
    {
        float relativeSpeed = Player.instance.speed / depth;
        Vector2 pos = transform.position;
        pos.x -= relativeSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
