using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public GameObject p1Wins;
    public GameObject p2Wins;

    public int winner;

    void Start()
    {
        
    }

    void Update()
    {
       if(winner == 1)
        {
            player1.SetActive(false);
            p1Wins.SetActive(true);
        }
        else if (winner == 2) {
            player2.SetActive(false);
            p2Wins.SetActive(true);
        };
    }
}
