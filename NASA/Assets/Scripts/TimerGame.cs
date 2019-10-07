using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerGame : MonoBehaviour
{
    
    public float CurrentTime = 5;
    float CurrentBreakTime = 0;
    public TextMeshProUGUI timertext;

    public Vector3 initialPos;
    public Vector3 actualPosition;
    public float StartTIme = 10;
    public float BreakTime = 2;
    public GameObject player;
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    Mouse_Behaviour PlayerMouse_Behaviour;
    Audio_Behaviour PlayAudio_Behaviour;
    bool started = false;
    bool firstDeath = true;
    public Camera cameraFollow;

    private bool FallCase = false;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        playerRigidbody = player.GetComponent<Rigidbody>();
        initialPos = playerRigidbody.position;
        initialPos.y += 2;
        PlayerMouse_Behaviour = player.GetComponent<Mouse_Behaviour>();
        PlayAudio_Behaviour = player.GetComponent<Audio_Behaviour>();
    }

    public void StartTimer()
    {
        started = true;
    }

    public void addTime(float additionnal)
    {
        CurrentTime+=additionnal;
        StartTIme += additionnal;
    }

    protected void FixedUpdate ()
    {
        timertext.text = "Time Left : "+CurrentTime;
        actualPosition = playerRigidbody.position;
        if (!started)
        {
            return;
        }
        if
            (CurrentTime > 0)
        {
            // Play part
            CurrentTime -= Time.fixedDeltaTime;
        }
        if
            ((CurrentTime <= 0 && CurrentBreakTime <= 0) || actualPosition.y < -15)
        {
            if (actualPosition.y < -15)
            {
                FallCase = true;
            }
            // Play part is finished, we go back to the beginning
            CurrentBreakTime = BreakTime;           
            PlayerMouse_Behaviour.canMove = false;
            playerRigidbody.position = initialPos;    
            if (firstDeath && cameraFollow)
            {
                Camera.main.gameObject.SetActive(false);
                cameraFollow.gameObject.SetActive(true);
                firstDeath = false;
            }  
            PlayAudio_Behaviour.timerOut = true;        
        }  
         if
            ((CurrentTime <= 0 && CurrentBreakTime > 0) || FallCase)
        {
            // Break party during tempsint2 seconds. we can't move
            CurrentBreakTime -= Time.fixedDeltaTime;
           
            if (CurrentBreakTime <= 0)
            {
                // The break part is finished, we can play
                PlayerMouse_Behaviour.canMove = true;
                CurrentTime = StartTIme;
                CurrentBreakTime = 0;
                FallCase = false;
            }
        }   
    }
}
