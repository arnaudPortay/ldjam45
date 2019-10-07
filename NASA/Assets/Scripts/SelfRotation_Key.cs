using UnityEngine;
using System.Collections;

/**
 * Self rotation for objects to pick up.
 */

public class SelfRotation_Key : MonoBehaviour {
    public float rotationSpeed = 300;
    public float baseSpeed = 300;
    public Vector3 RotationAxis = new Vector3(0,1,0);

    public float factor =1.0f;
    public float way = 1.0f;

    public bool canRotate = true;
    public void rotationChange(float newspeed)
    {
        rotationSpeed = baseSpeed * newspeed;
    }
    protected void FixedUpdate () 
    {
        if (rotationSpeed !=0)
        {
            // TODO : desactivate when the object is picked up
            Vector3 move = RotationAxis*rotationSpeed;
            // Set the movement vector based on the axis input.
            transform.Rotate (move * factor * Time.fixedDeltaTime);
        }
        
    }
}