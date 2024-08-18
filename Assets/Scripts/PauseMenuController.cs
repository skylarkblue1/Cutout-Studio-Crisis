using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pausePopup;

    public void OnRestartButton()
    {
        SceneManager.LoadScene(1); //Make sure this goes to the overall shop view scene
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnUnpauseButton()
    {
        pausePopup.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnPauseButton()
    {
        pausePopup.SetActive(true);
        Time.timeScale = 0;
    }
}
