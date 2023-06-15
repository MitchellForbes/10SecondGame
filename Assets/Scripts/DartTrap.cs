using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DartTrap : MonoBehaviour
{

    public GameObject dart; // the dart prefab
    public GameObject dartShooterObject; // The dart shooter object
    public Transform dartSpawn; // the spawn position for the dart
    public Quaternion dartRotation; // the spawn rotation on the dart
    public GameObject timerObject; 

    public float dartSpawnDelay = 1f;
    private float dartSpawnTime = 0f;

    private void Start()
    {
        dartRotation = dartShooterObject.transform.rotation;   
    }

    // Update is called once per frame
    void Update()
    {

        dartSpawnTime += Time.deltaTime; // adds to the time to spawn the dart

        if(dartSpawnTime >= dartSpawnDelay && Timer.allowInput == true) // if the time to spawn is greater then the delay spawn the dart and reset the time
        {
            dart.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Level";
            dart.GetComponentInChildren<SpriteRenderer>().sortingOrder = 3;
            Instantiate(dart, dartSpawn.position, dartRotation, dartShooterObject.transform);
            dartSpawnTime = 0;
        }
    }
}
