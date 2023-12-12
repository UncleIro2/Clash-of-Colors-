using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public int Respawn;
    public GameManager gm;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player 1"))
        {
            gm.winner = 2;
            Time.timeScale = 0;
        }
        else other.CompareTag("Player 2");
        {
            gm.winner = 1;
            Time.timeScale = 0;
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Respawn);
    }
}
