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
    public float tilt = 2.0f;
    // The time at which the animation started.
    private float startTime;
    Vector3 initialpos;
    Quaternion initialRotation;
     Vector3 initialRelativPos;
    Quaternion initialRelativRot;
    Vector3 newpos;
    Vector3 intermediatePos;

    public GameObject Queue;
    public float AdditionnalTime = 5.0f;

    public bool relocate = false;
    public bool relocate2 = false;
    void Start ()
    {
        initialpos = cameraFollow.transform.position;
        initialRelativPos = transform.InverseTransformVector(initialpos);
        initialRotation = cameraFollow.transform.rotation;
        initialRelativRot = Quaternion.Inverse(transform.rotation) * initialRotation;
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
            Vector3 setRelCenter = intermediatePos - center;

            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.
            float fracComplete = (Time.fixedTime - startTime) / journeyTime;

            cameraFollow.transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            cameraFollow.transform.position += center;
            if (Vector3.Distance(cameraFollow.transform.position, intermediatePos) < 0.0001f)
            {
                setTurning(false,1);
            }
        }
        else if (relocate2)
        {
            cameraFollow.transform.LookAt(transform.position);
            // The center of the arc
            Vector3 center = transform.position;

            // Interpolate over the arc relative to center
            Vector3 riseRelCenter = intermediatePos - center;
            Vector3 setRelCenter = initialpos - center;

            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.
            float fracComplete = (Time.time - startTime) / journeyTime;

            cameraFollow.transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            cameraFollow.transform.position += center;
            if (Vector3.Distance(cameraFollow.transform.position, initialpos) < 0.0001f)
            {
                setTurning(false,0);
            }
        }
        
    }
    void setTurning(bool sure, int rel)
    {
        if (sure)
        {
            // initialisation de starttime, newpos et intermediatePos
            Vector3 relativePos = initialpos - transform.position;
            Vector3 relocation = relativePos;
            relocation.z *=-2;
            relocation.x*=-2;
            cameraFollow.transform.position = transform.position + relocation;
            newpos = cameraFollow.transform.position;
            intermediatePos = new Vector3(0,1,0); // up vector
            Vector3 vectProd = Vector3.Cross(intermediatePos,newpos);
            vectProd.Normalize();
            intermediatePos+=vectProd*tilt;
            print("initial pos : "+initialpos);
            print("relocation: "+relocation);
            print("intermediatePos : "+intermediatePos);

            Mouse_Behaviour behave = GetComponent<Mouse_Behaviour>();
            if (behave)
            {
                behave.canMove = !sure;
            }
            Mouse_Rotation rotate = Queue.GetComponent<Mouse_Rotation>();
            if (rotate)
            {
                rotate.canRotate = !sure;
            }
        }
        if (rel == 1)
        {
            relocate = sure;
            relocate2 = !sure;
            startTime = Time.fixedTime;
        }
        else
        {
            //fin
            relocate2 = sure;
            //cameraFollow.transform.rotation = Quaternion.Inverse(transform.rotation) * initialRotation;
            //cameraFollow.transform.position = transform.TransformVector(initialRelativPos);
            Mouse_Behaviour behave = GetComponent<Mouse_Behaviour>();
            if (behave)
            {
                behave.canMove = !sure;
            }
            Mouse_Rotation rotate = Queue.GetComponent<Mouse_Rotation>();
            if (rotate)
            {
                rotate.canRotate = !sure;
            }
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
                setTurning(true,1);
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