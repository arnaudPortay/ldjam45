using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Rotation : Ability
{
    Vector3 movement;                   // The vector to store the direction of the player's movement.                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    public float rotateSpeed = 200;

     new protected void InitAbility ()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        playerRigidbody = subject.GetComponent<Rigidbody>();
    }

    protected void FixedUpdate ()
    {
        // Store the input axes.
        float y = Input.GetAxisRaw("Horizontal");
        if 
            (y !=0)
        {
            // Change the rotation player
            TurningToMouse (y);
        }  
    }

    void TurningToMouse (float h)
    {
        if (!playerRigidbody)
        {
            InitAbility();
        }

        // Set the movement vector based on the axis input.
        movement.Set (0f, h, 0f);

        // Normalise the movement vector and make it proportional to the rotate speed per second.
        movement = movement.normalized * rotateSpeed;

        // Move the player to it's current position plus the movement.
        Quaternion deltaRotation = Quaternion.Euler(movement * Time.deltaTime);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
    }
}
