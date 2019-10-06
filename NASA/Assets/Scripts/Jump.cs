using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Jump : Ability
{
    public bool jumping = false;
    Rigidbody playerRigidbody; 
    public float jumpStr = 1.0f;
    public float timebeforejump = 0.0f;
    public bool timerstarted = false;
    public float delay = 0.05f;
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
        if (timerstarted)
        {
            if (timebeforejump < 0)
            {
                delayedWork();
                timerstarted = false;
            }
            else
            {
                timebeforejump -= Time.fixedDeltaTime;
            }
        }
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
    public void delayedWork()
    {
        //print("delayed call");
        jumping = false;
    }
    public override void ListenerEventHandler(Collider other) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (other.gameObject.CompareTag (ground))
        {
            timebeforejump = delay;
            timerstarted = true;
        }
    }

}
