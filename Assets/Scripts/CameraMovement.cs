using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private Transform lookAt; // Instantiate Transform

    private Vector3 startOffset; // Instantiate the starting Offset of player
    private Vector3 moveVector; // Instantiate move Vector 
    private Vector3 animationOffset = new Vector3(0,5,5); //Instantiate Animation Offset
     
    private float transition = 0.0f;
    private float animationDuration = 2.0f;

    // Use this for initialization
    void Start ()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform; // Look At is assigned as Player's transform data
        startOffset = transform.position - lookAt.position; // Initial Offset is assigned
    }
	
	// Update is called once per frame
	void Update ()
    {
        moveVector = lookAt.position + startOffset; // Declare moveVector
        // X Axis
        moveVector.x = 0; // Lock X Axis
        // Y Axis
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5); // Camera locked Y axis between 3 & 5.
        
        // Z Axis
        if (transition>1.0f)
        {
            transform.position = moveVector; // Position of the Camera is now player position
        }
        else
        {
            // Animation at start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
    }
}
