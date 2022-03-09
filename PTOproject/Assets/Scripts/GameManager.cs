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
    public int points = 0;
    public int redKey;
    public int greenKey;
    public int purpleKey;

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
        PickupCheck();
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

    public void AddPoints(int point)
    {
        points = point + points;
    }

    public void AddTime(int addTime)
    {
        timeLeft += addTime;
    }

    public void RemoveTime(int minusTime)
    {
        timeLeft -= minusTime;
    }

    public void FreezeTime(int freezeTime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezeTime, 1);
    }

    public void AddKey(KeyColor color)
    {
        if(color == KeyColor.Green)
        {
            greenKey++;
        }
        if (color == KeyColor.Red)
        {
            redKey++;
        }
        if (color == KeyColor.Purple)
        {
            purpleKey++;
        }
    }

    void PickupCheck()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("RedKey: " + redKey + " GreenKey: " + greenKey + " PurpleKey: " + purpleKey + " Points: " + points);
        }
    }
}
