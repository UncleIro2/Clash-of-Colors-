using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private Vector3 orgPlayer1Pos;
    private Vector3 orgPlayer2Pos;

    public int winner;

    public int Score1 = 0;
    public int Score2 = 0;
    public TMPro.TMP_Text Score1txt;
    public TMPro.TMP_Text Score2txt;
    public GameObject p1Wins;
    public GameObject p2Wins;

    void Start()
    {
        orgPlayer1Pos = player1.transform.position;
        orgPlayer2Pos = player2.transform.position;
    }
    void Update()
    {
       if(winner == 1)
        {
            winner = 99;
            p1Wins.SetActive(true);
            Score1txt.text = Score1.ToString();
        }
        else if (winner == 2) {
            winner = 99;
            p2Wins.SetActive(true);
            Score2txt.text = Score2.ToString();
        }
    }
    public void ResetScene()
    {
        player1.transform.localPosition = orgPlayer1Pos;
        player2.transform.localPosition = orgPlayer2Pos;
        player1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // TODO: Reset powerup
        Time.timeScale = 1;
        p1Wins.SetActive(false);
        p2Wins.SetActive(false);
    }
}
