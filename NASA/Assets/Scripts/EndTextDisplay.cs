using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTextDisplay : MonoBehaviour
{
    public bool mIsDisplayed;
    // Start is called before the first frame update
    public int mDeathCounter = 0;

    public TextMeshProUGUI mGameObject;

    void DisplayText()
    {
        mGameObject.text = "Congratulations ! \nYou won the game in " + mDeathCounter + " generations.";
        mGameObject.enabled = true;
    }

    void HideText()
    {
        mGameObject.enabled = false;
    }

    void Start ()
    {
    }

    void FixedUpdate ()
    {
    }
}
