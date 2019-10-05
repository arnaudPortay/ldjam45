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

    void OnTriggerEnter(Collider other) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
            // TODO : setSubject to ability object
        }
    }
}