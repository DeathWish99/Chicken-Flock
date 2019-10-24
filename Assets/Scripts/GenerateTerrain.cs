using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    const float CONST_PLAYER_END_DISTANCE = 200f;
    [SerializeField] private Transform levelPart_start;
    [SerializeField] private Transform levelPart_1;
    [SerializeField] private Transform player;
    private Vector3 lastEndPosition;

    bool spawnCheck = false;
    private void Awake()
    {
        lastEndPosition = levelPart_start.Find("EndPoint").position;
        //SpawnLevelPart();
    }

    private void Update()
    {
        //Spawn by time
        //if (!spawnCheck)
        //{
        //    spawnCheck = true;
        //    StartCoroutine(Generate(3f));
        //}

        //spawn by player distance
        if(CheckDistance())
        {
            SpawnLevelPart();
        }
            
    }

    private IEnumerator Generate(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);
        SpawnLevelPart();
        spawnCheck = false;
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

    private bool CheckDistance()
    {
        float distance = Vector3.Distance(player.position, lastEndPosition);

        if(distance < CONST_PLAYER_END_DISTANCE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
