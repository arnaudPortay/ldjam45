using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTextDisplay : MonoBehaviour
{
    public bool mIsDisplayed;
    // Start is called before the first frame update
    public int mDeathCounter = 0;
    public GameObject SpriteEnd;
    public float timebeforejump = 5;
    public bool timerstarted = false;

    public void DisplayText()
    {
        GetComponent<TextMeshProUGUI>().enabled = false;
        timerstarted = true;
    }

    void HideText()
    {
        GetComponent<TextMeshProUGUI>().enabled = false;
    }

    void Start ()
    {
    }

    void FixedUpdate ()
    {
        if (!timerstarted)
        {
            return;
        }
        if (timebeforejump < 0)
        {
            SpriteEnd.SetActive(true);
            GetComponent<TextMeshProUGUI>().text = "Congratulations ! \nYou won the game in " + mDeathCounter + " generations.";
            GetComponent<TextMeshProUGUI>().enabled = true;
            for (int i=0; i<transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            timerstarted = false;
        }
        else
        {
            timebeforejump -= Time.fixedDeltaTime;
        }
        
    }
}
