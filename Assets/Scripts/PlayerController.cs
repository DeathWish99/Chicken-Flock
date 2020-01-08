using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;
    private float jumpForce = 8f;
    private float invinTimer = 1.5f;
    public float fallMultiplier;
    public float lowJumpMultiplier;


    private bool isTouching;

    Rigidbody2D rb;

    private Flock flock;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isTouching = true;
    }
    void Start()
    {
        flock = GetComponentInChildren<Flock>();
    }

    // Update is called once per frame
    
    void Update()
    {
        
        MoveControls();
       
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
        }
    }
    
    void MoveControls()
    {

        if (isTouching)
        {
            rb.velocity = Vector2.right * speed;
        }
        //if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isTouching)
        if (Input.GetKeyDown(KeyCode.Space) && isTouching)
        {
            isTouching = false;
            rb.velocity = new Vector2(speed, jumpForce);
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

            Debug.Log("pressed");
        }
        //else if(rb.velocity.y > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }
    }
}
