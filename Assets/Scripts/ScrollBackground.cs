using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed;
    Vector3 startPosition;
    private float repeatWidth;
    public float depth;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        float relativeSpeed = Player.instance.speed / depth;
        Vector2 pos = transform.position;
        pos.x -= relativeSpeed * Time.deltaTime;
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            pos = startPosition;
        }
        transform.position = pos;
    }
}
