using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageController : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text scoreText;

    public float timer;

    public GameObject endScreen;
    public TMP_Text endText;

    public void Awake()
    {
        scoreText.text = "Score: " + PersistenceManager.Instance.score;
    }

    public void Update()
    {
        timer = PersistenceManager.Instance.timer;

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = "Time Remaining: " + niceTime;

        if (PersistenceManager.Instance.timer <= 0)
        {
            endText.text = "Congratulations!\nYou've completed the day and completed " + PersistenceManager.Instance.ordersComplete + " orders!\n\nYour Final Score: " + PersistenceManager.Instance.score;
            endScreen.SetActive(true);

            Time.timeScale = 0;
        }
    }
}