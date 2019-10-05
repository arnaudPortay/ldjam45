using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

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
        TriggerEventSystem triggerEventSystem= subject.GetComponent<TriggerEventSystem>();
        if (triggerEventSystem)
        {
            triggerEventSystem.registerListener (this);
        }
    }

    protected void FixedUpdate ()
    {
        if (!subject)
        {
            return;
        }
        // Store the input axes.
        bool j = Input.GetKey(KeyCode.Space);
        
        if 
            (j && !jumping)
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
    private async Task delayedWork()
    {
        await Task.Delay(50);
        jumping = false;
    }
    public override void ListenerEventHandler(Collider other) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (other.gameObject.CompareTag (ground))
        {
            this.delayedWork();
        }
    }

}
