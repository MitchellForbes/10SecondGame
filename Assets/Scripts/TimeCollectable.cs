using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCollectable : MonoBehaviour
{

    [SerializeField] private GameObject timerObject;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player")) // compares to see if what touchs it has the player tag
        {
            Debug.Log("Time Added");
            Timer setTime = timerObject.GetComponent<Timer>();
            setTime.Addtime();
            Destroy(gameObject);
        }
    }
}
