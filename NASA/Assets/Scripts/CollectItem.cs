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

    public GameObject Queue;
    public float AdditionnalTime = 5.0f;

    public bool relocate = false;
	public Transform pathParent;
	Transform targetPoint;

    Vector3 oldPosition;
    Quaternion oldOrientation;
	int index;
    Audio_Behaviour PlayAudio_Behaviour;

	void OnDrawGizmos()
	{
		Vector3 from;
		Vector3 to;
		for (int a=0; a<pathParent.childCount; a++)
		{
			from = pathParent.GetChild(a).position;
			to = pathParent.GetChild((a+1) % pathParent.childCount).position;
			Gizmos.color = new Color (1, 0, 0);
			Gizmos.DrawLine (from, to);
		}
	}
	
    void Start ()
    {
        index = 0;
		targetPoint = pathParent.GetChild (index);
        PlayAudio_Behaviour = GetComponent<Audio_Behaviour>();
    }

    void FixedUpdate ()
    {
        if (relocate)
        {
           cameraFollow.transform.LookAt(transform.position);
           cameraFollow.transform.position = Vector3.MoveTowards (cameraFollow.transform.position, targetPoint.position, journeyTime * Time.fixedDeltaTime);
            if (Vector3.Distance (cameraFollow.transform.position, targetPoint.position) < 0.1f) 
            {
                index++;
                index %= pathParent.childCount;
                targetPoint = pathParent.GetChild (index);
                if (index == 0)
                {
                    setTurning(false);
                }
            }
        }
        
    }
    void setTurning(bool sure)
    {
        if (sure)
        {
            oldPosition = cameraFollow.transform.position;
            cameraFollow.transform.position = targetPoint.position;
            oldOrientation = cameraFollow.transform.rotation;
        }
        else
        {
            cameraFollow.transform.rotation = oldOrientation;
            cameraFollow.transform.position = oldPosition;
        }
        //fin
        relocate = sure;
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
            PlayAudio_Behaviour.itemSound();
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