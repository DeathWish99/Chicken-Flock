using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOnHit : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
        }
            
    }
}
