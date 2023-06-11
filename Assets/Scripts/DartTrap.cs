using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrap : MonoBehaviour
{

    public GameObject dart; // the dart prefab
    public Transform dartSpawn; // the spawn position for the dart
    public Quaternion dartRotation; // the spawn rotation on the dart

    public float dartSpawnDelay = 1f;
    private float dartSpawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        dartSpawnTime += Time.deltaTime; // adds to the time to spawn the dart

        if(dartSpawnTime >= dartSpawnDelay) // if the time to spawn is greater then the delay spawn the dart and reset the time
        {
            Instantiate(dart, dartSpawn.position, dartRotation);
            dartSpawnTime = 0;
        }
    }
}
