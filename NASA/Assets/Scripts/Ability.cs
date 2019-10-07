using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ability : MonoBehaviour
{
    void Start ()
    {
        gameObject.tag = "Pick Up";
    }

    public GameObject subject; 
    public GameObject RelatedPart;

    public GameObject mText;
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
        DisplayText();
    }

    virtual protected void InitAbility ()
    {
    }

    virtual protected void DisplayText ()
    {
        //Debug.Log("Display text ask");
        if (!mText)
        {
            mText = GameObject.Find("AbilityText");
        }

        if (mText)
        {
            //Debug.Log("Display text ok");
            mText.GetComponent<PickUpTextDisplay>().SetText(GetPickUpText(), GetPresentationText());
        }
        
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
