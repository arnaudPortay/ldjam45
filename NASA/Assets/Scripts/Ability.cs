using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    void Start ()
    {
        gameObject.tag = "Pick Up";
    }

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

    virtual public void ListenerEventHandler(Collider other) 
    {
        //print(" triggered ability ");
    }
}
