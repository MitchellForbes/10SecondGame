using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    private float speed = 5f; // dart flying speed
    private GameObject timerObject;

    private void Start()
    {
        timerObject = GetComponentInParent<DartTrap>().timerObject;
    }

    private void Update()
    { 
        transform.position += speed * transform.right * Time.deltaTime; // moces the dart
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision detected - TriggerEnter2D");

        if (other.CompareTag("Player")) // compares to see if what touchs it has the player tag
        {
            Debug.Log("The dart hit the player");
            Timer setTime = timerObject.GetComponent<Timer>();
            setTime.Traps();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Debug.Log("The dart hit the ground");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // compares to see if what touchs it has the player tag
        {
            Debug.Log("The dart hit the player");
            Timer setTime = timerObject.GetComponent<Timer>();
            setTime.Traps();
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Debug.Log("The dart hit the ground");
            Destroy(gameObject);
        }
    }
}
