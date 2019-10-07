using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpTextDisplay : MonoBehaviour
{
    public bool mIsDisplayed;
    // Start is called before the first frame update
    public string mFirstLine;
    public string mSecondLine;

    public float mDisplayDurationTime = 4.0f;
    private float mCurrentTime;

    public TextMeshProUGUI mGameObject;
    
    public void SetText(string pFirstLine, string pSecondLine)
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        mGameObject.text = pFirstLine + "\n" + pSecondLine;
        mCurrentTime = mDisplayDurationTime;
        mIsDisplayed = true;
    }

    void Start ()
    {
    }

    void FixedUpdate ()
    {
        if (mIsDisplayed)
        {
            mCurrentTime -= Time.fixedDeltaTime;

            if (mCurrentTime <= 0)
            {
                mGameObject.text = "";
            }
        }
    }
}
