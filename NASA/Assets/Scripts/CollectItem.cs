using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

/**
 * Used to collect ability items and activate them.
 */

public class CollectItem : MonoBehaviour {

    public GameObject GameEngine;
    public UnityEvent EndGameEvent;

    public GameObject cameraFollow;
    // Time to move from sunrise to sunset position, in seconds.
    public float journeyTime = 1.0f;

    // The time at which the animation started.
    private float startTime;
    Vector3 initialpos;
    Vector3 newpos;
    public float AdditionnalTime = 5.0f;

    public bool relocate = false;
    public bool relocate2 = false;
    void Start ()
    {
        initialpos = cameraFollow.transform.position;
    }

    void FixedUpdate ()
    {
        if (relocate)
        {
            cameraFollow.transform.LookAt(transform.position);
            // The center of the arc
            Vector3 center = transform.position;

            // Interpolate over the arc relative to center
            Vector3 riseRelCenter = newpos - center;
            Vector3 setRelCenter = initialpos - center;

            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.
            float fracComplete = (Time.time - startTime) / journeyTime;

            cameraFollow.transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            cameraFollow.transform.position += center;
            if (Vector3.Distance(cameraFollow.transform.position, initialpos) < 0.0001f)
            {
                setTurning(false);
            }
        }
        else if (relocate2)
        {
            
        }
        
    }
    void setTurning(bool sure)
    {
        if (sure)
        {
            Vector3 relocation = initialpos - transform.position;
            relocation.z *=-1.5f;
            relocation.x*=-2;
            cameraFollow.transform.position = transform.position + relocation;
            newpos = cameraFollow.transform.position;
            startTime = Time.time;
        }
        relocate = sure;
        Mouse_Behaviour behave = GetComponent<Mouse_Behaviour>();
        if (behave)
        {
            behave.canMove = !sure;
        }
}
    void OnTriggerEnter(Collider pOther) 
    {
        // If the object collided has the "Pick Up" tag, take it.
        if 
            (pOther.gameObject.CompareTag ("Pick Up"))
        {
            // Desactive the object (for now)
            //pOther.gameObject.SetActive (false);
            pOther.gameObject.tag = "Picked";
            // Get the ability component
            Ability lAbilityObject = pOther.gameObject.GetComponent(typeof(Ability)) as Ability;
            if
                (lAbilityObject != null)
            {
                lAbilityObject.setSubject(gameObject);
            }
            if (GameEngine)
            {
                GameEngine.GetComponent<TimerGame>().addTime(AdditionnalTime);
            }
            if (cameraFollow)
            {
                setTurning(true);
            }
        }
        else if (pOther.gameObject.CompareTag("endZone")) 
        {
            if (EndGameEvent != null)
            {
                EndGameEvent.Invoke();
            }
        }
    }
}