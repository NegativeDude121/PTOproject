using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField]int timeLeft;
    bool gamePaused = false;
    bool gameWon = false;
    bool endGame = false;

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }

        if (timeLeft <= 0)
        {
            timeLeft = 100;
        }

        InvokeRepeating("Stopper", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        pausedCheck();
    }

    void Stopper()
    {
        timeLeft--;
        Debug.Log("Time: " + timeLeft + "s");

        if(timeLeft <= 0)
        {
            endGame = true;
            timeLeft = 0;
        }

        if (endGame)
        {
            EndGame();
        }
    }

    public void pauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void resumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void pausedCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                resumeGame();
            }

            else
            {
                pauseGame();
            }
        }
        
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");

        if(gameWon)
        {
            Debug.Log("You win");
        }
        else
        {
            Debug.Log("You lose");
        }
    }
}
