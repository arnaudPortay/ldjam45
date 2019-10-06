using UnityEngine;
using System.Collections;

/**
 * Self rotation for objects to pick up.
 */

public class SelfSwipe : MonoBehaviour {
    public float rotationSpeed = 300;
    public Vector3 RotationAxis = new Vector3(0,1,0);
    void Update () 
    {
        // TODO : desactivate when the object is picked up
        Vector3 move = RotationAxis*rotationSpeed;
        // Set the movement vector based on the axis input.
        transform.Rotate (move * Time.deltaTime);
        Vector3 angles = transform.eulerAngles;
        print("angles :"+angles);
    }
}