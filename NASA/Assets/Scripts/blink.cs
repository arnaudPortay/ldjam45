using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blink : MonoBehaviour
{
    public int duration = 2;
    private float counter = 0.0f;
    private float counterbis = 0.0f;
    
    private float blinkDuration = 0.1f;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    protected void FixedUpdate()
    {
        counter += Time.fixedDeltaTime;
        counterbis += Time.fixedDeltaTime;

        if (counter <= duration)
        {
            if (counterbis >= blinkDuration)
            {
                counterbis = 0.0f;
                image.enabled = !image.enabled;                
            }            
        }
    }
}
