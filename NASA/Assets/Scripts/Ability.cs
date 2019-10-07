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
    public GameObject RelatedPart;
    // Start is called before the first frame update
    public void setSubject(GameObject g)
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        subject = g;
        if (RelatedPart)
        {
            RelatedPart.SetActive(true);
        }
        MeshRenderer msh = GetComponent<MeshRenderer>();
        if (msh)
        {
            msh.enabled = false;
        }
        foreach (MeshRenderer childmesh in GetComponentsInChildren<MeshRenderer>())
        {
            if (childmesh) childmesh.enabled = false;
        }
        
        InitAbility();
    }

    virtual protected void InitAbility ()
    {
    }

    virtual public void ListenerEventHandler(Collider other) 
    {
        //print(" triggered ability ");
    }

    virtual public string GetPickUpText()
    {
        return "";
    }

    virtual public string GetPresentationText()
    {
        return "";
    }

    virtual public string GetAbilityName()
    {
        return "";
    }

    virtual public string GetAbilityKey()
    {
        return "";
    }
}
