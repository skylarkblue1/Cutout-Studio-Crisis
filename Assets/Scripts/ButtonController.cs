using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public GameObject tutorialPopup;

    public GameObject creditsPopup;

    public void OnPlayButton()
    {
        SceneManager.LoadScene(1); //Make sure this goes to the overall shop view scene
    }


    public void OnTutorialButton()
    {
        tutorialPopup.SetActive(true);
    }
    public void OnTutorialClose()
    {
        tutorialPopup.SetActive(false);
    }


    public void OnCreditsButton()
    {
        creditsPopup.SetActive(true);
    }

    public void OnCreditsClose()
    {
        creditsPopup.SetActive(false);
    }


    public void OnQuitButton()
    {
        Application.Quit();
    }
}
