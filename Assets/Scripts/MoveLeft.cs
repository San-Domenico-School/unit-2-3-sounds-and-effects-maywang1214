using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
 * Helps the obstacles and background to move left
 * 
 * Yuqin Wang
 * October 25, 2023 version 1.0
 * ****************************************************/

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private float leftBound = -15;
    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x < -9 && gameObject.tag == "Obstacles")
        {
            Destroy(gameObject);
        }
    }
}
