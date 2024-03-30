using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    public int playerScore = 0;
    
    public int maxScore = 2;
    public Text scoreText;

    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")] // test the specific script
    public void addScore(int scoreToAdd) 
    {
        Debug.Log("Adding Score");
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    [ContextMenu("Restart Game")] // test the specific script
    public void restartGane()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("Game Over")] // test the specific script
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    [ContextMenu("Game Over")] // test the specific script
    public void Exit()
    {
        Application.Quit();
    }

    public int getMaxScore()
    {
        return maxScore;
    }

    public void setMaxScore(int i)
    {
        maxScore = i;
    }
}   