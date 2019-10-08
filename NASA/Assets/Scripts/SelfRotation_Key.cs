using UnityEngine;
using System.Collections;

/**
 * Self rotation for objects to pick up.
 */

public class SelfRotation_Key : MonoBehaviour {
    public float rotationSpeed = 300;
    public float baseSpeed = 300;
    public Vector3 RotationAxis = new Vector3(0,1,0);
    public AudioClip rewind;
    public AudioClip use;
    public float factor =1.0f;
    public float way = 1.0f;

    public bool canRotate = true;
    AudioSource mySource;
    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }
    public void startUse(float remainingTime)
    {
        mySource.clip =rewind; //use;
        mySource.loop = true; //false;
        mySource.pitch =  0.5f ;//use.length/remainingTime;
    }
    public void pauseUse()
    {
        if (mySource.isPlaying)
        {
            mySource.Pause();
        }
    }
    public void unpauseUse()
    {
        if (!mySource.isPlaying)
        {
            mySource.Play();
        }
        else
        {
             mySource.UnPause();
        }
    }
    public void startRewind()
    {
        mySource.pitch = 1.0f;
        mySource.clip = rewind;
        mySource.loop = true;
        mySource.Play();
    }
    public void rotationChange(float newspeed)
    {
        rotationSpeed = baseSpeed * newspeed;
    }
    protected void FixedUpdate () 
    {
        if (rotationSpeed !=0)
        {
            // TODO : desactivate when the object is picked up
            Vector3 move = RotationAxis*rotationSpeed;
            // Set the movement vector based on the axis input.
            transform.Rotate (move * factor * Time.fixedDeltaTime);
        }
        
    }
}