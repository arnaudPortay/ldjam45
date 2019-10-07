using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePillar : MonoBehaviour
{
    public GameObject CurrentCamera = null;

    // Start is called before the first frame update
    void Start()
    {
        if (CurrentCamera)
        {
            CurrentCamera.tag = "Untagged";
            
            
            GameObject FinalCamera = GameObject.Find("FinalCamera");

            FinalCamera.tag = "MainCamera";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
