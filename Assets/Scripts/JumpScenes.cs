using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour


{
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadGuide()
    {
        SceneManager.LoadScene("Guide");

    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadSune()
    {
        SceneManager.LoadScene("Sune");
    }
    public void LoadEyüp()
    {
        SceneManager.LoadScene("Eyüp");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadLucas()
    {
        SceneManager.LoadScene("Lucas");
    }
    public void LoadMarcus()
    {
        SceneManager.LoadScene("Marcus");
    }
    public void LoadArda()
    {
        SceneManager.LoadScene("Arda");
    }
    public void LoadMapSelector()
    {
        SceneManager.LoadScene("MapSelector");
    }
    public void LoadForrest()
    {
        SceneManager.LoadScene("Forrest");
    }
}
