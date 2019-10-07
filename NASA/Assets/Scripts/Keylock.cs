﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keylock : MonoBehaviour
{
    public float MaxDuration = 3.0f;

    public string LockKey = "nasa";

    public GameObject Doors;

    string currentSequence = "";
    bool isInside = false;

    float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInside)
        {
            currentSequence += Input.inputString;
            
            counter += Time.fixedDeltaTime;
            if (counter > MaxDuration)
            {
                currentSequence = "";
                counter = 0;
            }

            if(currentSequence == LockKey)
            {
                if (Doors != null)
                {
                    for (int i=0; i<Doors.transform.childCount; i++)
                    {
                        Doors.transform.GetChild(i).GetComponent<Animator>().SetBool("OpenDoor", true);
                    }
                }
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
            currentSequence = "";
            counter = 0;
        }
    }
}
