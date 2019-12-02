using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float speed;
    float upOrDown;
    float jumpForce = 500f;

    bool isTouching;

    void Start()
    {
        isTouching = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isTouching)
         if (Input.GetMouseButtonDown(0) && isTouching)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            isTouching = false;
        }
        transform.Translate(new Vector3(speed, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            isTouching = true;
        }
    }
}
