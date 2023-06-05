using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timer = 10;
    public GameObject gameOverUI;
    public GameObject player;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {


        DisplayTime(timer);

        if (gameOverUI.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Debug.Log("scene reloaded");

        }
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
        }

        if (timer <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Time Frozen");
            gameOverUI.SetActive(true);
            timer = 10;
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
