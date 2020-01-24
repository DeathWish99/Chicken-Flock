using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float jumpForce = 8f;
    private float invTimer;
    public float speed;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float invTime;
    private Animator anim;

    public GameObject manager;

    private bool isTouching;
    private bool isInv;

    Rigidbody2D rb;

    private Flock flock;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isTouching = true;
        isInv = false;
    }
    void Start()
    {
        flock = GetComponentInChildren<Flock>();
        
        invTimer = invTime;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    
    void Update()
    {
        
        MoveControls();
        //InvincibleControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {

            isTouching = true;
        }

        if (collision.collider.CompareTag("Obstacle"))
        {
            flock.lives -= 1;

            Destroy(flock.chicks[flock.lives]);
            flock.chicks.Remove(flock.chicks[flock.lives]);

            collision.collider.enabled = false;

            //Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
            //tmp.a = 150f;
            //gameObject.GetComponent<SpriteRenderer>().color = tmp;

            //gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            //isInv = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            manager.GetComponent<GameManager>().coin += 1 * manager.GetComponent<GameManager>().coinMultiplier;
        }
    }
    void MoveControls()
    {

        if (isTouching)
        {
            rb.velocity = Vector2.right * speed;
            anim.Play("Chicken_Walk");
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isTouching)
        //if (Input.GetKeyDown(KeyCode.Space) && isTouching)
        {
            isTouching = false;
            rb.velocity = new Vector2(speed, jumpForce);
            if (anim.GetBool("Mariachi") == false)
            {
                anim.Play("Chicken_Jump");
            }
            else if (anim.GetBool("Mariachi") == true)
            {
                anim.Play("Chicken.Mariachicken_Jump");
            }
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if(rb.velocity.y > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        //else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }
    }

    //void InvincibleControl()
    //{
    //    if (isInv)
    //    {
    //        invTimer -= Time.deltaTime;
    //        Debug.Log(invTimer);
    //    }

    //    if(invTimer <= 0)
    //    {
    //        isInv = true;
    //        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
    //        tmp.a = 255f;
    //        gameObject.GetComponent<SpriteRenderer>().color = tmp;

    //        gameObject.GetComponent<Collider2D>().enabled = true;

    //        invTimer = invTime;
    //        Debug.Log(isInv);
    //    }
    //}
}
