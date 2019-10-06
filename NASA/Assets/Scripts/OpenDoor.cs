using UnityEngine;
using System.Collections;
using System;

/**
 * Used to collect ability items and activate them.
 */

public class OpenDoor : MonoBehaviour {


    void Start ()
    {
    }

    void FixedUpdate ()
    {
    }

    void OnTriggerEnter(Collider pOther) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (pOther.gameObject.CompareTag ("Door"))
        {
            // Desactive the object (for now)
            //pOther.gameObject.SetActive (false);
            pOther.gameObject.tag = "Door Opened";
            // Get the ability component
            Door lDoor = pOther.gameObject.GetComponent(typeof(Door)) as Door;
            if
                (lDoor != null)
            {
                lDoor.setOpen(true);
            }
        }
    }
}