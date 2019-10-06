using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{
    
    float temps = 5;
    float temps2 = 0;
    public Text timertext;
    public int tempsint = 10;
    public int tempsint2 = 2;
    public GameObject player;
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    Mouse_Behaviour PlayerMouse_Behaviour;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        playerRigidbody = player.GetComponent<Rigidbody>();
        PlayerMouse_Behaviour = player.GetComponent<Mouse_Behaviour>();
    }

    protected void FixedUpdate ()
    {
        if
            (temps > 0)
        {
            // Play part
            temps -= Time.fixedDeltaTime;
        }
        if
            (temps <= 0 && temps2 <= 0)
        {
            // Play part is finished, we go back to the beginning
            temps2 = tempsint2;           
            PlayerMouse_Behaviour.canMove = false;
            playerRigidbody.position = new Vector3(0, 1, 0);              
        }  
         if
            (temps <= 0 && temps2 > 0)
        {
            // Break party during tempsint2 seconds. we can't move
            temps2 -= Time.fixedDeltaTime;
           
            if (temps2 <= 0)
            {
                // The break part is finished, we can play
                PlayerMouse_Behaviour.canMove = true;
                temps = tempsint;
                temps2=0;
            }
        }  
    }
}
