using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // used when the player clicks the play and sends to the first level or the level after the menu in build settings
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // quits the game when quit is click
    }
}
