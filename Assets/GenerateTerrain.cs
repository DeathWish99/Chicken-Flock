using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    [SerializeField] private Transform levelPart_1;
    private void Awake()
    {
        Instantiate(levelPart_1, new Vector3(29.92f, -2.4f, 0), Quaternion.identity);
    }

}
