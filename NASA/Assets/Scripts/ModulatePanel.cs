using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulatePanel : MonoBehaviour
{
    // The Albedo of the material
    public Color AlbedoWeak;
    public Color AlbedoStrong;

    public Color EmissionWeak;
    public Color EmissionStrong;

    public bool Activated;

    void Start ()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", AlbedoWeak);
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", EmissionWeak);
    }

    public void Activate(bool pActivate)
    {
        if
            (pActivate)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", AlbedoStrong);
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", EmissionStrong);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", AlbedoWeak);
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", EmissionWeak);
        }
        
        Activated = pActivate;
    }

    void Update ()
    {
    }
}
