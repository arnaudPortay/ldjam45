using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Behaviour : MonoBehaviour
{
    public float speed = 6f;   
    Vector3 movement;                   // The vector to store the direction of the player's movement.                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    public float rotateSpeed = 0;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        playerRigidbody = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate ()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Vertical");
        float y = Input.GetAxisRaw("Horizontal");
        
        if 
            (h !=0)
        {
            // Move the player around the scene.
            Move (h);
        }  
        if 
            (y !=0)
        {
            // Change the rotation player
            TurningToMouse (y);
        }  
    }

    void Move (float h)
    {
        // Set the movement vector based on the axis input.
        movement.Set (0f, 0f, h);
        
        // Normalise the movement vector and make it proportional to the speed per second.
        movement = transform.TransformVector(movement).normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition (transform.position + movement);

    }

    void TurningToMouse (float h)
    {

        // Set the movement vector based on the axis input.
        movement.Set (0f, h, 0f);

        // Normalise the movement vector and make it proportional to the rotate speed per second.
        movement = movement.normalized * rotateSpeed;

        // Move the player to it's current position plus the movement.
        Quaternion deltaRotation = Quaternion.Euler(movement * Time.deltaTime);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
    }
}
