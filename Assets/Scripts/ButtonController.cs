using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnTutorialButton()
    {
        // Show tutorial images slideshow
    }

    public void OnCreditsButton()
    {
        // Show credits image
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
