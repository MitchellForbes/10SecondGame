using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private GameObject timerObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player")) // compares to see if what touchs it has the player tag
        {
            Debug.Log("Trigger with spike");
            Timer setTime = timerObject.GetComponent<Timer>();
            setTime.Traps();
        }
    }

}
