using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField] private float timer;
    private float time = 0;
   
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > timer)
        {
            Destroy(gameObject);
        }
    }
}
