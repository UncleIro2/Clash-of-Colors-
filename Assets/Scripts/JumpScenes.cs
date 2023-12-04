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


}
public class ButtonClick : MonoBehaviour 
{
    public SceneTransition sceneTransition;

    private void OnButtonClick()

    {
        sceneTransition.LoadSampleScene();
    }
}
