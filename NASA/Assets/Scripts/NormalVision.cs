using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NormalVision : Ability
{
    bool mNormalVisionActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void InitAbility ()
    {
        // Get the main camera of the scene
        Camera lCamera = Camera.main;
        if
            (lCamera != null)
        {
            // Get the camera effect to desactivate the blur
            CameraEffect lCameraEffect = lCamera.GetComponent(typeof(CameraEffect)) as CameraEffect;

            if
                (lCameraEffect != null)
            {
                mNormalVisionActivated = true;
                lCameraEffect.enabled = false;
            }
        }

        if
            (!mNormalVisionActivated)
        {
            Console.WriteLine("Impossible to desactivate the blur vision.");
        }
    }

    protected void FixedUpdate ()
    {
    }

}
