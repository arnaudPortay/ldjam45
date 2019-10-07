using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorZone : MonoBehaviour
{
    public string ColorZoneTag = "ColorZone";

    public Light mLight;

    public GameObject[] mPlanes = new GameObject[3];

    private bool mWatchLightColor = false;
    public bool mZoneActivated = false; 

    private Color mLastColorSeen = Color.green;

    public Color[] mColors = new Color[3] { Color.blue, Color.white, Color.red};
    public int mColorToCompareIndex = 0;
    public GameObject Doors;

    private void Start()
    {
        gameObject.tag = ColorZoneTag;
    }

    protected void FixedUpdate()
    {
        if 
            (!mZoneActivated && mWatchLightColor)
        {
            if 
                (mLight.enabled && mLight.color !=  mLastColorSeen)
            {
                Debug.Log("Same color");
                if
                    (mColors[mColorToCompareIndex] == mLight.color)
                {
                    mPlanes[mColorToCompareIndex].GetComponent<ModulatePanel>().Activate(true);
                    mColorToCompareIndex += 1;
                    Debug.Log("+1");
                }
                else
                {
                    for
                        (int lIndex = 0; lIndex < mColorToCompareIndex; lIndex++)
                    {

                        mPlanes[lIndex].GetComponent<ModulatePanel>().Activate(false);
                    }
                    mColorToCompareIndex = 0;
                }

                mLastColorSeen = mLight.color;
            }
            
        }

        if 
            (mColorToCompareIndex >= mColors.Length)
        {
            mZoneActivated = true;

            if (Doors != null)
            {
                for (int i=0; i<Doors.transform.childCount; i++)
                {
                    Doors.transform.GetChild(i).GetComponent<Animator>().SetBool("OpenDoor", true);
                }
            }
        }
    }

    void OnTriggerEnter(Collider pOther) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (pOther.gameObject.CompareTag ("Player"))
        {
            mWatchLightColor = true;
        }
    }

     void OnTriggerExit(Collider pOther) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (pOther.gameObject.CompareTag ("Player"))
        {
            mWatchLightColor = false;
        }
    }
           
}
