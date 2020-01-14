using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    const float CONST_PLAYER_END_DISTANCE = 200f;
    const float CONST_LEVEL_PART_Y = 7.48f;
    [SerializeField] private Transform levelPart_start;
    [SerializeField] private Transform levelPart_1;
    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> obstacle;
    private Vector3 lastEndPosition;
    private Vector3 spawnLocation;

    public GameObject coin;

    int spawnNum;
    int obstacleIdx;
    int coinNum;

    float initialX = 0;
    float lastX;

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
        initialX = lastEndPosition.x;
        lastEndPosition = lastLevelPartTransform.Find("EndPoint").position;
        lastX = lastEndPosition.x;
        SpawnObstacle();
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

    private void SpawnObstacle()
    {
        List<Vector3> placedPositions = new List<Vector3>();
        spawnNum = Random.Range(1, 3);
        coinNum = Random.Range(3, 8);

        placedPositions.Add(new Vector3(-100, -100));
        for(int i = 0; i < spawnNum; i++)
        {
            obstacleIdx = Random.Range(0, 2);
            do
            {
                spawnLocation = new Vector3(Random.Range(initialX, lastX), CONST_LEVEL_PART_Y);
            } while (spawnLocation.x <= placedPositions[i].x + 4 && spawnLocation.x >= placedPositions[i].x - 4);
            Instantiate(obstacle[obstacleIdx], spawnLocation, Quaternion.identity);
            placedPositions.Add(spawnLocation);
        }

        for(int i = 0; i < coinNum; i++)
        {
            spawnLocation = new Vector3(Random.Range(initialX, lastX), CONST_LEVEL_PART_Y);
            Instantiate(coin, spawnLocation, Quaternion.identity);
        }
        
    }
}
