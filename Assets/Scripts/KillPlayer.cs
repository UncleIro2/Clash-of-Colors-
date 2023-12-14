using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public string sceneName;
    public GameManager gm;


    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player 1"))
        {
            gm.winner = 2;
            gm.Score2 += 1;
            Time.timeScale = 0;
        }
        else if(other.CompareTag("Player 2"))
        {
            gm.winner = 1;
            gm.Score1 += 1;
            Time.timeScale = 0;
        }
    }
}
