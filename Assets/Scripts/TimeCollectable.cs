using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCollectable : MonoBehaviour
{

    [SerializeField] private GameObject timerObject;

    // Declaration of the variable to do the collectable sfx
    [SerializeField] private AudioClip collectSFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // compares to see if what touchs it has the player tag
        {
            Debug.Log("Time Added");
            Timer setTime = timerObject.GetComponent<Timer>();
            setTime.Addtime();
            AudioSource.PlayClipAtPoint(collectSFX, transform.position);
            Destroy(gameObject);
        }
    }
}
