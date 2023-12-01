using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*******************************************************
 * Helps manage the game
 * 
 * Yuqin Wang
 * November 15, 2023 version 1.0
 * ****************************************************/

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboardText, timeRemainingText;
    [SerializeField] private GameObject toggleGroup, startButton, spawnManager;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ParticleSystem dirtSplatter;
    public static bool gameOver = true;
    private static float score;
    private AudioSource audioSource;
    private int timeRemaining = 60;
    private bool timedGame;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        DisplayUI();
        EndGame();
    }

    private void DisplayUI()
    {
        scoreboardText.text = "Score: " + Mathf.RoundToInt(score).ToString();
        if (timedGame == true)
        {
            if (timeRemaining != 0)
            {
                timeRemainingText.text = timeRemaining.ToString();
            }
            else
            {
                timeRemainingText.text = "Game\nOver";
            }
        }
        else
        {
            timeRemainingText.text = "";
        }
        if (gameOver == true)
        {
            timeRemainingText.text = "Game\nOver";
        }
    }

    private void TimeCountdown()
    {
        timeRemaining--;
    }

    public void StartGame()
    {
        audioSource.Play();
        toggleGroup.SetActive(false);
        startButton.SetActive(false);
        if (timedGame == true)
        {
            timeRemainingText.gameObject.SetActive(true);
            InvokeRepeating("TimeCountdown", 1, 1);
        }
        gameOver = false;
        spawnManager.SetActive(true);
        playerAnimator.SetBool("BeginGame_b", true);
        dirtSplatter.Play();
    }

    private void EndGame()
    {
        if (gameOver || timeRemaining == 0)
        {
            gameOver = true;
            playerAnimator.SetBool("BeginGame_b", false);
            playerAnimator.SetFloat("Speed_f", 0);
            audioSource.Stop();
            CancelInvoke();
        }
    }

    public void SetTimed(bool timed)
    {
        timedGame = timed;
    }

    public static void ChangeScore(int change)
    {
        score += change;
    }
}
