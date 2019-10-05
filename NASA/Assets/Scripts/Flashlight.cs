using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Flashlight : Ability
{
    // All available colors
    public Color[] mColors = new Color[5] { Color.white, Color.yellow, Color.red, Color.green, Color.blue};

    private Light myLight;
     bool Toggleable = true;
    private int mCurrentColorIndex;

    void Start()
    {
        mCurrentColorIndex = 0;
    }
    protected override void InitAbility ()
    {
        print("initialized");

        myLight = GetComponent<Light>();

        if
            (myLight)
        {
             print("mylight OK");
            myLight.color = mColors[mCurrentColorIndex];
            myLight.enabled = true; 
        }
    }
    private async Task delayedWork()
    {
        await Task.Delay(200);
        Toggleable = true;
    }
    void FixedUpdate ()
    {

        if
            ( !myLight)
        {
            return;
        }
        print("active");
        if(Toggleable && Input.GetKey(KeyCode.R))
        {
            Toggleable = false;
            //print("toggled");
            myLight.enabled = !myLight.enabled;
            this.delayedWork();
        }

        // F key to change the color of the light
        if
            (Toggleable && Input.GetKey(KeyCode.F))
        {
            Toggleable = false;

            mCurrentColorIndex = (mCurrentColorIndex + 1) % mColors.Length;
            myLight.color = mColors[mCurrentColorIndex];

            this.delayedWork();
        }
    }
}
