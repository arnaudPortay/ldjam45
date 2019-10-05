using UnityEngine;
using System.Collections;
using System;

/**
 * Used to collect ability items and activate them.
 */

public class CollectItem : MonoBehaviour {


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
            
            // Get the ability component
            Ability lAbilityObject = pOther.gameObject.GetComponent(typeof(Ability)) as Ability;
            if
                (lAbilityObject != null)
            {
                lAbilityObject.setSubject(gameObject);
            }
        }
    }
}