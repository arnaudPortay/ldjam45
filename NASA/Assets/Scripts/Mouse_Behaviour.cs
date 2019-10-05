using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Behaviour : MonoBehaviour
{
    public float speed = 10f;   
    Vector3 movement;                   // The vector to store the direction of the player's movement.                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        playerRigidbody = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate ()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Vertical");
        
        if 
            (h !=0)
        {
            // Move the player around the scene.
            Move (h);
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
}
