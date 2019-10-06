using UnityEngine;
using System.Collections;

/**
 * Self rotation for objects to pick up.
 */

public class SelfSwipe : MonoBehaviour {
    public float rotationSpeed = 300;
    public float minValue = 45;
    public float maxValue = 145;
    public Vector3 RotationAxis = new Vector3(0,1,0);
    public float way = 1.0f;
    void Update () 
    {
        // TODO : desactivate when the object is picked up
        Vector3 move = RotationAxis*rotationSpeed*way;
        // Set the movement vector based on the axis input.
        transform.Rotate (move * Time.deltaTime);
        Vector3 angles = transform.eulerAngles;
        float product = angles.z*RotationAxis.z+angles.x*RotationAxis.x+angles.y*RotationAxis.y;
        print("product :"+product);
        if (product >maxValue|| product < minValue)
        {
            way *= -1;
        }
    }
}