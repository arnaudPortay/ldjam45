using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public GameObject subject; 
    // Start is called before the first frame update
    public void setSubject(GameObject g)
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        subject = g;
        InitAbility();
    }

    virtual protected void InitAbility ()
    {
    }
}
