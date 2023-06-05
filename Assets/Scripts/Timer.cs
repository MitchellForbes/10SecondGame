using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timer = 10; // base timer used set to 10 as base
    public GameObject gameOverUI; // the gameover ui
    public GameObject player; // player game object
    public Text timeText; // text used for the timer

    // Start is called before the first frame update
    void Start()
    {
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {


        DisplayTime(timer); // calls the display timer fuction

        if (gameOverUI.activeSelf && Input.GetKeyDown(KeyCode.Space)) // resets the scene if gameover ui is active and then player press space
        {
            Time.timeScale = 1;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Debug.Log("scene reloaded");

        }
        if (timer > 0) // makes timer only go down when above 0
        {
            timer = timer - Time.deltaTime;
        }

        if (timer <= 0) // used for when timer hits 0 to froze character and displays the over screen
        {
            Time.timeScale = 0;
            Debug.Log("Time Frozen");
            gameOverUI.SetActive(true);
            timer = 10;
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0) // used for when the timer is less then 0 and sets the time display 0
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); // math to create minutes from the timer
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // math to create seconds from the timer
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // displays the minutes and second from the timer
    }
}