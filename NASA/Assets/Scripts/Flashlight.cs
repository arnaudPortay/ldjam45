using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Ability
{
    // All available colors
    Color[] mColors = new Color[5] { Color.white, Color.yellow, Color.red, Color.green, Color.blue};

    private Light myLight;

    private int mCurrentColorIndex;

    void Start()
    {
        mCurrentColorIndex = 0;
    }

    protected override void InitAbility ()
    {
        if
            (!subject)
        {
            return;
        }
        myLight = subject.GetComponent<Light>();

        if
            (myLight)
        {
            myLight.color = mColors[mCurrentColorIndex];
            myLight.enabled = true; 
        }
    }

    void Update ()
    {
        if
            (!subject)
        {
            return;
        }

        // Space key to enable the light
        if
            (Input.GetKeyUp(KeyCode.Space))
        {
            myLight.color = mColors[mCurrentColorIndex];
            myLight.enabled = !myLight.enabled; 
        }

        // F key to change the color of the light
        if
            (Input.GetKeyUp(KeyCode.F))
        {
            mCurrentColorIndex = (mCurrentColorIndex + 1) % mColors.Length;
            myLight.color = mColors[mCurrentColorIndex];
        }
    }
}
