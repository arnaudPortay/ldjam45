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
    public float timebeforeend = 0.0f;
    public bool timerstarted = false;
    public float delay = 0.05f;
    void Start()
    {
        mCurrentColorIndex = 0;
    }
    protected override void InitAbility ()
    {
        //print("initialized");
        if (RelatedPart)
        {
            myLight = RelatedPart.GetComponent<Light>();
        }
        
        if
            (myLight)
        {
             //print("mylight OK");
            myLight.color = mColors[mCurrentColorIndex];
            myLight.enabled = true; 
        }
    }
    private void delayedWork()
    {
        Toggleable = true;
    }
    void FixedUpdate ()
    {
        if (timerstarted)
        {
            if (timebeforeend < 0)
            {
                delayedWork();
                timerstarted = false;
            }
            else
            {
                timebeforeend -= Time.fixedDeltaTime;
            }
        }
        if
            ( !myLight)
        {
            return;
        }
        //print("active");
        if(Toggleable && Input.GetKey(KeyCode.R))
        {
            Toggleable = false;
            //print("toggled");
            myLight.enabled = !myLight.enabled;
            timebeforeend = delay;
            timerstarted = true;
        }

        // F key to change the color of the light
        if
            (Toggleable && Input.GetKey(KeyCode.F))
        {
            Toggleable = false;

            mCurrentColorIndex = (mCurrentColorIndex + 1) % mColors.Length;
            myLight.color = mColors[mCurrentColorIndex];

            timebeforeend = delay;
            timerstarted = true;
        }
    }

    virtual public string GetPickUpText()
    {
        return "You picked a nose !";
    }

    virtual public string GetPresentationText()
    {
        return "You have new the possibilty to illuminate your world with [R]. If you want some color in your life, press [F].";
    }

    virtual public string GetAbilityName()
    {
        return "Flashlight/Color";
    }

    virtual public string GetAbilityKey()
    {
        return "[R]/[F]";
    }
}
