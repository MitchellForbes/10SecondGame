using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialHandler : MonoBehaviour
{
    // Declaration of the main camera and the positions it will move to
    [SerializeField] private Camera mainCamera;
    [SerializeField] private List<GameObject> cameraPositions;
    [SerializeField] private List<float> cameraZoom;
    private float targetZoom;
    private float zoomSpeed = 0.5f;

    // Declaration of some Int to track current position and the max amount of positions
    private int currentCameraPosition;

    // Declaration of the SFX for each of the comic panels
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource footstepSFX;
    [SerializeField] private AudioSource caveInSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.transform.position = cameraPositions[0].transform.position;
        mainCamera.orthographicSize = cameraZoom[currentCameraPosition];
        currentCameraPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks to see if the enter key or the mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            // CHecks to see if the current posisition is at max and then loads the next scene
            if (currentCameraPosition == cameraPositions.Count - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            // CHange the current camera vairable to +1
            currentCameraPosition++;
        }

        // Checks to see if the position of the camera needs to be moved
        if (mainCamera.transform.position != cameraPositions[currentCameraPosition].transform.position)
        {
            // Moves the camera to the new position
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPositions[currentCameraPosition].transform.position, Time.deltaTime);
        }

        // Checks to see if the current camera zoom is the same as the variable 
        if (mainCamera.orthographicSize != cameraZoom[currentCameraPosition])
        {
            // Moves the camera zoom slowly
            targetZoom = cameraZoom[currentCameraPosition];
            float newSize = Mathf.MoveTowards(mainCamera.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
            mainCamera.orthographicSize = newSize;
        }

        if (currentCameraPosition == 2)
        {
            Vector3 originalCameraPosition = cameraPositions[currentCameraPosition].transform.position;
            float shakeAmount = 0.1f;
            mainCamera.transform.localPosition = originalCameraPosition + Random.insideUnitSphere * shakeAmount;
        }

        PlaySFX();
        Debug.Log("currentCameraPosition = " + currentCameraPosition);
    }

    // Method that plays the audio SFX based on which current camera position it is at
    private void PlaySFX()
    {
        // CHecks to see if the camera is in the first position
        if (currentCameraPosition == 0 && footstepSFX.isPlaying == false)
        {
            footstepSFX.Play();
        }

        // Checks to see if the camera is in the third position and that the sound is already playing (bug fix)
        if (currentCameraPosition == 2 && caveInSFX.isPlaying == false) 
        {
            footstepSFX.Stop();
            caveInSFX.Play();
            caveInSFX.loop = true;
        }
    }
}
