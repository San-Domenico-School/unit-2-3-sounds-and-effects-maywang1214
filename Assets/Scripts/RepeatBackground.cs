using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
 * Helps repeat backgrounds
 * 
 * Yuqin Wang
 * October 25, 2023 version 1.0
 * ****************************************************/

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent< BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
