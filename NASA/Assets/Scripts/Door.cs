using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    protected bool mIsOpened;
    // Start is called before the first frame update
    public void setOpen(bool isOpened)
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        mIsOpened = isOpened;
        if
            (mIsOpened)
        {
            ActivateOpenAnimation();
        }
    }

    virtual protected void ActivateOpenAnimation ()
    {
        gameObject.SetActive(false);
    }

    void Start ()
    {
        mIsOpened = false;
        gameObject.tag = "Door";
    }

    void FixedUpdate ()
    {
    }
}
