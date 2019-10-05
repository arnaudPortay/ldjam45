using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Flashlight : Ability
{
    private Light myLight;
     bool Toggleable = true;
    void Start()
    {
        
    }

    protected override void InitAbility ()
    {
        //print("initialized");
        myLight = GetComponent<Light>();
    }
    private async Task delayedWork()
    {
        await Task.Delay(200);
        Toggleable = true;
    }
    void FixedUpdate ()
    {
        if(myLight && Toggleable && Input.GetKey(KeyCode.R))
        {
            Toggleable = false;
            //print("toggled");
            myLight.enabled = !myLight.enabled;
            this.delayedWork();
        }
    }
}
