using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor5 : MonoBehaviour
{
   public GameObject Doors;
   public GameObject player;

   Mouse_Behaviour behave;

    // Start is called before the first frame update
    void Start()
    {
        behave = player.GetComponent<Mouse_Behaviour>();
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (Doors != null && behave.mDoor5AlwaysOpen && !areDoorsOpened())
        {                            
            openDoors();
        }
        
    }

    void OnTriggerEnter(Collider pOther) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (pOther.gameObject.CompareTag ("Player"))
        {
            //mContact = true;
            if (Doors != null && !behave.mDoor5AlwaysOpen)
            {                
                openDoors();
            }
        }
    }

     void OnTriggerExit(Collider pOther) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (pOther.gameObject.CompareTag ("Player"))
        {
            //mContact = false;
            if (Doors != null && !behave.mDoor5AlwaysOpen)
            {
                closeDoors();
            }
        }
    }

    void openDoors()
    {
        // Launch opening animation
        for (int i=0; i<Doors.transform.childCount; i++)
        {
            Doors.transform.GetChild(i).GetComponent<Animator>().SetBool("OpenSlideDoor", true);;
        }
    }

    void closeDoors()
    {
        // Launch closing animation
        for (int i=0; i<Doors.transform.childCount; i++)
        {
            Doors.transform.GetChild(i).GetComponent<Animator>().SetBool("OpenSlideDoor", false);;
        }
    }

    bool areDoorsOpened()
    {
        return Doors.transform.GetChild(0).GetComponent<Animator>().GetBool("OpenSlideDoor");
    }
}
