using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject p1Wins;
    public GameObject p2Wins;

    public int winner;

    public int Score1 = 0;
    public int Score2 = 0;
    public TMPro.TMP_Text Score1txt;
    public TMPro.TMP_Text Score2txt;

    void Update()
    {
       if(winner == 1)
        {
            player1.SetActive(false);
            p1Wins.SetActive(true);
            Score1txt.text = Score1.ToString();
        }
        else if (winner == 2) {
            player2.SetActive(false);
            p2Wins.SetActive(true);
            Score2txt.text = Score2.ToString();
        }
    }
    public void LoadFantastiskeUI()
    {
        SceneManager.LoadScene("FantastiskeUI");
        Time.timeScale = 1;
    }
}
