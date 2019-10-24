using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    [SerializeField] private Transform levelPart_start;
    [SerializeField] private Transform levelPart_1;

    private Vector3 lastEndPosition;

    private IEnumerator coroutine;
    private void Awake()
    {
        lastEndPosition = levelPart_start.Find("EndPoint").position;
        SpawnLevelPart();
    }

    private void Update()
    {
        coroutine = Generate(3f);
        StartCoroutine(coroutine);
    }

    private IEnumerator Generate(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPartPosition(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPoint").position;
    }

    private Transform SpawnLevelPartPosition(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
