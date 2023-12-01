using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
 * Helps spawn new things
 * 
 * Yuqin Wang
 * October 25, 2023 version 1.0
 * ****************************************************/

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    private Vector3 SpawnPos = new Vector3(25, 0, -2);
    private float startDelay = 2;
    private float repeatRate = 2;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, SpawnPos, obstaclePrefab.transform.rotation);
        if(GameManager.gameOver)
        {
            CancelInvoke();
        }
    }
}
