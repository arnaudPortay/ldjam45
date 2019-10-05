using UnityEngine;
using System.Collections;

/**
 * Self rotation for objects to pick up.
 */

public class SelfRotation : MonoBehaviour {

    void Update () 
    {
        // TODO : desactivate when the object is picked up

        transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);
    }
}