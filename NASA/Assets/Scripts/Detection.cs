using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : Ability
{
    public GameObject RevealedDoor;
    MeshRenderer DoorRenderer;
    public float newVisibility =0.1f;
    public float duration = 1.0f;
    public bool blinking = false;
    public Color target = Color.red;
    Color currentcolor;
    public GameObject minimap;
    // Start is called before the first frame update
    void Start()
    {
        blinking = false;
        if (RevealedDoor)
        {
           DoorRenderer = RevealedDoor.GetComponent<MeshRenderer>(); 
        }
        
    }

    protected override void InitAbility ()
    {
        blinking = true;
        currentcolor = DoorRenderer.material.color;
        RevealedDoor.GetComponent<MeshCollider>().enabled = false;
        minimap.SetActive(true);
    }

    protected void FixedUpdate ()
    {
       if (blinking && DoorRenderer)
       {
            currentcolor.a = newVisibility;
            float lerp = Mathf.PingPong(Time.fixedTime, duration) / duration;
            DoorRenderer.material.color = Color.Lerp(currentcolor, target, lerp);

       } 

    }

    
    public override string GetPickUpText()
    {
        return "Detection ability acquired";
    }

    public override string GetPresentationText()
    {
        return "You can now feel the environment.";
    }

}
