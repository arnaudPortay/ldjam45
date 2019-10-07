﻿using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        blinking = false;
        DoorRenderer = RevealedDoor.GetComponent<MeshRenderer>();
    }

    protected override void InitAbility ()
    {
        blinking = true;
        currentcolor = DoorRenderer.material.color;
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


}
