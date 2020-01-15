using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public GameObject chicken;
    public GameObject manager;
    public List<GameObject> chicks;
    

    private Vector3 offset;

    public int lives;

    private void Start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
        if(lives < 0)
        {
            manager.GetComponent<GameManager>().EndGame();
        }
    }
    void LateUpdate()
    {
        MoveFlock();
    }


    public void SpawnFlock()
    {
        
        for(int i = 0; i < lives; i++)
        {
            var chickObj = Instantiate(chicken, gameObject.transform.position, Quaternion.identity);
            chickObj.transform.parent = transform.parent;
            chicks.Add(chickObj);

            //transform.position += Vector3.left;
        }
    }

    void MoveFlock()
    {
        for(int i = 0; i < chicks.Count; i++)
        {
            offset = new Vector3(i + 1.5f, 0.6f);
            chicks[i].transform.position = transform.parent.position - offset;
        }
    }
}
