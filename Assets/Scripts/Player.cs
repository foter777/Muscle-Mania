using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask layerMask;
    public Transform feetPos;
    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool grounded = false;
    public bool jumping = false;
    public float jumpTime;
    private float jumpTimer;
    public static Player instance;
    public float acceleration;
    public float maxAcceleration;
    public float speed;
    public float maxSpeed;
    public float distance;
    public float health;
    // Start is called before the first frame update
    private void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feetPos.position, groundHeight,layerMask);
        if (grounded && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            jumpTimer = 0;
            jumping = true;
            rb.velocity = Vector2.up * jumpVelocity;
        }

        if (jumping && Input.GetKey(KeyCode.LeftAlt))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpVelocity;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                jumping = false;
            }
            
        }
        if(Input.GetKeyUp(KeyCode.LeftAlt))
        {
            jumping = false;
        }
        distance += speed * Time.deltaTime;
        if (grounded)
        {
            float speedRatio = speed/maxSpeed;
            acceleration = maxAcceleration * (1 - speedRatio);
            speed += acceleration * Time.deltaTime;
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        
    }


}
