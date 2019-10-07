using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor5 : MonoBehaviour
{
   public GameObject Doors;
   public GameObject player;
   bool mContact = false;
   Mouse_Behaviour behave;

    // Start is called before the first frame update
    void Start()
    {
        behave = player.GetComponent<Mouse_Behaviour>();
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (mContact || behave.mDoor5AlwaysOpen)
        {
            if (Doors != null)
            {
                for (int i=0; i<Doors.transform.childCount; i++)
                {
                    Doors.transform.GetChild(i).GetComponent<Animator>().SetBool("OpenSlideDoor", true);;
                }
            }
        }
        else if (!mContact && !behave.mDoor5AlwaysOpen)
        {
            if (Doors != null)
            {
                for (int i=0; i<Doors.transform.childCount; i++)
                {
                    Doors.transform.GetChild(i).GetComponent<Animator>().SetBool("OpenSlideDoor", false);;
                }
            }
        }
    }

    void OnTriggerEnter(Collider pOther) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (pOther.gameObject.CompareTag ("Player"))
        {
            mContact = true;
        }
    }

     void OnTriggerExit(Collider pOther) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (pOther.gameObject.CompareTag ("Player"))
        {
            mContact = false;
        }
    }
}
