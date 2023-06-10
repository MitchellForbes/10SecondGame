using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    private float tim;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player")) // compares to see if what touchs it has the player tag
        {
            Timer setTime = other.GetComponent<Timer>();
            setTime.Traps();
        }
    }

}
