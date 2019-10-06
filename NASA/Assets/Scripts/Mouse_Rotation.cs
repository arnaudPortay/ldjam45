using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Rotation : Ability
{
    
    public Vector3 sideAxis =  new Vector3(1,0,0);
    Vector3 movement;                   // The vector to store the direction of the player's movement.                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    public float rotateSpeed = 200;

    Quaternion baseRotation;

    public bool canRotate = true;

     new protected void InitAbility ()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        playerRigidbody = subject.GetComponent<Rigidbody>();
        //print ("Initialized rotation");
    }

    protected void FixedUpdate ()
    {
        if (!subject)
        {
            return;
        }
        
        // Store the input axes.
        float y = Input.GetAxisRaw("Horizontal");

        //print ("turning");
        // Change the rotation player
        TurningToMouse (y);
        
    }

    void TurningToMouse (float h)
    {
        if (!playerRigidbody)
        {
            InitAbility();
        }
        if (h!= 0 && canRotate)
        {
             Vector3 move = sideAxis*h;
            // Set the movement vector based on the axis input.
            movement.Set (move.x,move.y,move.z);

            // Normalise the movement vector and make it proportional to the rotate speed per second.
            movement = movement.normalized * rotateSpeed;

            // Move the player to it's current position plus the movement.
            Quaternion deltaRotation = Quaternion.Euler(movement * Time.deltaTime);
            playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);

        }
       
    }
}
