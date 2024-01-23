using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerToIce : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TMPro.TMP_Text TimerTxt;

    public void startTimer()
    {
        TimerOn = true;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("GO!");
                TimeLeft = 0;
                TimerOn = false;
                SceneManager.LoadScene("Ice");
            }
            TimerTxt.text = Mathf.FloorToInt(TimeLeft).ToString();
        }
    }
}
