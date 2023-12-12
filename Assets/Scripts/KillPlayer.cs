using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public string sceneName;
    
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player 1"))
        {
            SceneManager.LoadScene(sceneName);
        }
        else other.CompareTag("Player 2");
        { 
            SceneManager.LoadScene(sceneName);
        }
    }
}
