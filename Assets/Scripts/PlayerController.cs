using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*******************************************************
 * Component of the player, takes in user
 * imput to move and turn the player
 * 
 * Yuqin Wang
 * October 25, 2023 version 1.0
 * ****************************************************/

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce, gravityModifier;
    [SerializeField] private ParticleSystem explosionParticle, dirtParticle;
    [SerializeField] private AudioClip jumpSound, crashSound;
    private Animator playAnimation;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private bool isOnGround;
    public bool gameOver { get; private set; }

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        isOnGround = true;
        Physics.gravity *= gravityModifier;
    }

    void OnJump(InputValue input)
    {
        if (isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
