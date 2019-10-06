﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

/**
 * Used to collect ability items and activate them.
 */

public class CollectItem : MonoBehaviour {

    public UnityEvent EndGameEvent;

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
            (pOther.gameObject.CompareTag ("Pick Up"))
        {
            // Desactive the object (for now)
            //pOther.gameObject.SetActive (false);
            pOther.gameObject.tag = "Picked";
            // Get the ability component
            Ability lAbilityObject = pOther.gameObject.GetComponent(typeof(Ability)) as Ability;
            if
                (lAbilityObject != null)
            {
                lAbilityObject.setSubject(gameObject);
            }
        }
        else if (pOther.gameObject.CompareTag("endZone")) 
        {
            if (EndGameEvent != null)
            {
                EndGameEvent.Invoke();
            }
        }
    }
}