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
        playAnimation = GetComponent<Animator>();
    }

    void OnJump(InputValue input)
    {
        if (isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playAnimation.SetTrigger("Jump_trig");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            gameOver = true;
            playAnimation.SetBool("Death_b", true);
            playAnimation.SetInteger("DeathType_int", 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
