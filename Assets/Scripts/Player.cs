using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask layerMask;
    public Transform feetPos;
    public float jumpVelocity = 20;
    public float groundHeight = 20;
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
    public float maxDistance;
    public float health;
    public Animator animator;
    public Transform punchHitbox;
    public LayerMask enemyLayer;
    public float punchRange;
    private float punchTimer = 0;
    public float punchCooldown;
    public float damage;
    public SpriteRenderer spriteRenderer;
    public float protein;
    public float maxProtein;
    public float proteinModeDuration;
    public bool proteinMode;
    private Vector3 initalScale;
    public UIManager uIManager;
    public GameObject hitEffect;
    // Start is called before the first frame update
    private void Awake() 
    {
        instance = this;
        
    }
    void Start()
    {
        initalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feetPos.position, groundHeight,layerMask);
        if (grounded && Input.GetKeyDown(KeyCode.LeftAlt) && !proteinMode)
        {
            jumpTimer = 0;
            jumping = true;
            rb.velocity = Vector2.up * jumpVelocity;
            AudioManager.instance.PlayEffect(2);
        }

        if (jumping && Input.GetKey(KeyCode.LeftAlt) && !proteinMode)
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
        punchTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftControl) && !proteinMode)
        {
            if (punchTimer <= 0)
            {
                punchTimer = punchCooldown;
                Punch();
            }
            
        }

        if (protein == maxProtein)
        {
            proteinMode = true;
            StartCoroutine(ProteinMode());
           
        }

        if (health <= 0)
        {
            UIManager.instance.GameOver();
            Destroy(gameObject);    
        }
        
    }

    private void Punch()
    {
        animator.SetTrigger("Punch");
        AudioManager.instance.PlayEffect(5);
        Collider2D hitEnemy = Physics2D.OverlapCircle(punchHitbox.position, punchRange, enemyLayer);
        if (hitEnemy != null)
        {
            if (!hitEnemy.GetComponent<Enemy>().isObstacle)
            {
                GameObject newHitEffect = Instantiate(hitEffect, hitEnemy.transform.position, Quaternion.identity);
                Destroy(newHitEffect, 0.1f);
                hitEnemy.GetComponent<Enemy>().Damage(damage);
                AudioManager.instance.PlayEffect(1);
            }
        }
        

    }

    private IEnumerator ProteinMode()
    {
        transform.localScale = new Vector3(1,1,1) * 3f;
        yield return new WaitForSeconds(proteinModeDuration);
        transform.localScale = initalScale;
        protein = 0;
        uIManager.UpdateBar();
        yield return new WaitForSeconds(1f);
        proteinMode = false;

    } 
    

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(punchHitbox.position, punchRange);
    }


}
