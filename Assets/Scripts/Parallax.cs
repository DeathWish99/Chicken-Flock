using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float backgroundSize;

    public Transform camTransform;
    public Transform[] layers;
    private float viewZone = 40;
    private int leftIndex;
    private int rightIndex;
    private float constY;
    private float constZ;

    private void Start()
    {
        camTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
        constY = layers[0].transform.position.y;
        constZ = layers[0].transform.position.z;
    }
    private void Update()
    {
        if (camTransform.transform.position.x < layers[leftIndex].transform.position.x + viewZone)
        {
            ScrollLeft();
            Debug.Log(layers[0].transform.position);
            Debug.Log(layers[1].transform.position);
            Debug.Log(layers[2].transform.position);
        }
        else if (camTransform.transform.position.x > layers[leftIndex].transform.position.x - viewZone)
        {
            ScrollRight();
            Debug.Log(layers[0].transform.position);
            Debug.Log(layers[1].transform.position);
            Debug.Log(layers[2].transform.position);
        }
    }
    private void ScrollRight()
    {
        int lastLeft = rightIndex;
        layers[leftIndex].position = new Vector3(1 * (layers[rightIndex].position.x + backgroundSize), constY, constZ);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex > layers.Length)
            leftIndex = 0;
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = new Vector3(1 * (layers[leftIndex].position.x + backgroundSize), constY, constZ);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

}
