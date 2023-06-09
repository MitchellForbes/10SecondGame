using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) // compares to see if what touchs it has the player tag
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // changes the scene to next level
            Debug.Log("Level changed");
        }
    }
}
