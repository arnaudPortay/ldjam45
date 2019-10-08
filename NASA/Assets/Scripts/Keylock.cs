using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Keylock : MonoBehaviour
{
    public float MaxDuration = 3.0f;

    public string LockKey = "nasa";

    public GameObject Doors;

    string currentSequence = "";
    bool isInside = false;

    bool isCapturingSequence = false;

    float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInside && Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            if(Input.inputString.Length == 0)
            {
                return;
            }

            if(Input.inputString[0] == LockKey[0] && !isCapturingSequence)
            {
                resetSequenceCapture();
                isCapturingSequence = true;
            }

            currentSequence += Input.inputString;
            
            counter += Time.fixedDeltaTime;
            if (counter > MaxDuration)
            {
                resetSequenceCapture();
            }

            if(String.Compare(currentSequence, LockKey, true) == 0)
            {
                if (Doors != null)
                {
                    Doors.GetComponent<BoxCollider>().enabled = false;
                    for (int i=0; i<Doors.transform.childCount; i++)
                    {
                        Doors.transform.GetChild(i).GetComponent<Animator>().SetBool("OpenDoor", true);
                    }
                }
                resetSequenceCapture();
            }
        }
    }

    void OnTriggerEnter(Collider pOther) 
    {
        if (pOther.gameObject.CompareTag ("Player"))
        {
            isInside = true;
        }
    }

    void OnTriggerExit(Collider pOther)
    {
        if (pOther.gameObject.CompareTag ("Player"))
        {
            isInside = false;
            resetSequenceCapture();
        }
    }

    void resetSequenceCapture()
    {
        isCapturingSequence = false;
        currentSequence = "";
        counter = 0;
    }
}
