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

    void Update()
    {
        if (!GameManager.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x < leftBound && gameObject.tag == "Obstacles")
        {
            Destroy(gameObject);
        }
    }
}
