using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorZone : MonoBehaviour
{
    public string ColorZoneTag = "ColorZone";

    public Light mLight;

    public GameEngine gameEngine;

    public GameObject[] mPlanes = new GameObject[3];

    private bool mWatchLightColor = false;
    private bool mZoneActivated = false; 

    private Color mLastColorSeen = Color.green;

    public Color[] mColors = new Color[3] { Color.blue, Color.white, Color.red};
    public int mColorToCompareIndex = 0;

    private void Start()
    {
        gameObject.tag = ColorZoneTag;
    }

    private void Update()
    {
        if 
            (!mZoneActivated && mWatchLightColor)
        {
            if 
                (mLight.enabled && mLight.color !=  mLastColorSeen)
            {
                if
                    (mColors[mColorToCompareIndex] == mLight.color)
                {
                    mPlanes[mColorToCompareIndex].GetComponent<ModulatePanel>().Activate(true);
                    mColorToCompareIndex += 1;
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

            // TODO Open door
        }
    }

    void OnTriggerEnter(Collider pOther) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (pOther.gameObject.CompareTag ("Player"))
        {
            Debug.Log("Watch move");
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
            Debug.Log("Unwatch move");
        }
    }
           
}
