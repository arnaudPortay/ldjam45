using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Ability
{
    bool jumping = false;
    Rigidbody playerRigidbody; 
    public float jumpStr = 1.0f;

    public string ground = "Ground";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void InitAbility ()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        playerRigidbody = subject.GetComponent<Rigidbody>();
    }

    protected void FixedUpdate ()
    {
        if (!subject)
        {
            return;
        }
        // Store the input axes.
        bool j = Input.GetKey(KeyCode.J);
        
        if 
            (j && ! jumping)
        {
            jumping = true;
            // Move the player around the scene.
            jump();
        }  
    }

    private void jump()
    {
        if (!playerRigidbody)
        {
             playerRigidbody = subject.GetComponent<Rigidbody>();
        }
        playerRigidbody.AddForce(new Vector3(0,jumpStr,0),ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (other.gameObject.CompareTag (ground))
        {
            jumping = false;
        }
    }
}
