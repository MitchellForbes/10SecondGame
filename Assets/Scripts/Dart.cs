using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    private float speed = 5f; // dart flying speed

    // Start is called before the first frame update

    private void Update()
    {

        transform.position += speed * transform.right * Time.deltaTime; // moces the dart
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        
        if (other.CompareTag("Player")) // compares to see if what touchs it has the player tag
        {
            Timer setTime = other.GetComponent<Timer>();
            setTime.Traps();
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Ground")) // checks if it hit anything with the ground tag
        {
            Destroy(gameObject);
        }

    }


}
