using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretLevel : MonoBehaviour
{
    private void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (other.CompareTag("Player")) // compares to see if what touchs it has the player tag
        {
            Debug.Log("Trigger with secret entrance");
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Secret Enter");
                SceneManager.LoadScene(21);
            }
        }
    }
}
