using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Behaviour : MonoBehaviour
{
    public float speed = 5f; 
    public Vector3 frontAxis =  new Vector3(0,1,0);
    Vector3 movement;                   // The vector to store the direction of the player's movement.                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    public bool canMove = true;
    RigidbodyConstraints oldConstraints;

    public Vector3 initialPos;
    public Quaternion initialRot;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        playerRigidbody = GetComponent<Rigidbody>();
        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Vertical");
        
        if 
            (h !=0 && canMove)
        {
            // Move the player around the scene.
            Move (h);
        } 
        
        
    }

    void Move (float h)
    {
        Vector3 move = frontAxis*h;
        // Set the movement vector based on the axis input.
        movement.Set (move.x,move.y,move.z);
        
        // Normalise the movement vector and make it proportional to the speed per second.
        movement = transform.TransformVector(movement).normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition (transform.position + movement);
    }

    public void stopMovement(bool sure)
    {
         Rigidbody rb = GetComponent<Rigidbody>();
        if (sure)
        {
            oldConstraints = rb.constraints;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rb.constraints = oldConstraints;
        }
    }

    void OnTriggerEnter(Collider other) 
    {

        if 
            (other.gameObject.CompareTag ("CheckPoint"))
        {
            print("New CHeckpoint reached !");
            initialPos = other.gameObject.transform.position;
            initialRot = transform.rotation;
        }
    }
}
