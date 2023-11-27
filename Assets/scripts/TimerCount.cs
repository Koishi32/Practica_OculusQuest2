using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 300;
    public bool timerIsRunning = false;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject LoseScreen;
    private void Start()
    {
        Time.timeScale = 1;
        LoseScreen.SetActive(false);
#if UNITY_EDITOR
        timeRemaining = 30;
#endif
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                LoseScreen.SetActive(true);
                Invoke("LoseBeing", 2);
            }
        }
    }

    public void LoseBeing() {
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}