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
    public Slider timerSlider; 
    private bool FallCase = false;
    private Color newColour;
    private GameObject fill; 
    private Image fillImage;

    public GameObject Key;
    SelfRotation_Key sk;
    public float breakTimeModifier = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        playerRigidbody = player.GetComponent<Rigidbody>();
        
        PlayerMouse_Behaviour = player.GetComponent<Mouse_Behaviour>();
        PlayAudio_Behaviour = player.GetComponent<Audio_Behaviour>();
        //Slider
        timerSlider.maxValue = StartTIme;
        fill = timerSlider.transform.GetChild (1).GetChild (0).gameObject; 
        fillImage = fill.GetComponent<Image> ();
        sk = Key.GetComponent<SelfRotation_Key>();  
    }

    public void StartTimer()
    {
        started = true;
    }

    public void addTime(float additionnal)
    {
        CurrentTime+=additionnal;
        StartTIme += additionnal;
        BreakTime += additionnal/breakTimeModifier;
        timerSlider.maxValue = StartTIme;
    }

    protected void FixedUpdate ()
    {
        timertext.text = "Time Left : "+CurrentTime;
        actualPosition = player.transform.position;
        if (!started)
        {
            return;
        }
        if
            (CurrentBreakTime > 0 || FallCase)
        {
            // Break party during tempsint2 seconds. we can't move
            CurrentBreakTime -= Time.fixedDeltaTime;
            CurrentTime = (BreakTime-CurrentBreakTime)*StartTIme/BreakTime;
            newColour = new Color( 0,0,0); // black
            if (CurrentBreakTime <= 0)
            {
                // The break part is finished, we can play
                PlayerMouse_Behaviour.canMove = true;
                CurrentTime = StartTIme;
                CurrentBreakTime = 0;
                FallCase = false;
                PlayerMouse_Behaviour.stopMovement(false);
            }
        }   
        else if (PlayerMouse_Behaviour.canMove) //other behaviour that restrict movement don't make timer run
        {
            if // decompte
                (CurrentTime > 0)
            {
                // Play part
                CurrentTime -= Time.fixedDeltaTime;
                sk.rotationChange(CurrentTime/StartTIme);
                newColour = new Color(                                             
                                    1f - (timerSlider.value/timerSlider.maxValue),     // R - empty
                                    0f,            // G - full
                                    timerSlider.value/timerSlider.maxValue                                       // B - Unused
                                );
            }
            if // fin du decompte
                (CurrentTime <= 0  || (actualPosition.y < -15 && !FallCase))
            {
                if (actualPosition.y < -15)
                {
                    FallCase = true;
                }
                // Play part is finished, we go back to the beginning
                CurrentBreakTime = BreakTime;           
                //PlayerMouse_Behaviour.canMove = false;
                
                player.transform.position = PlayerMouse_Behaviour.initialPos;
                player.transform.rotation = PlayerMouse_Behaviour.initialRot;
                actualPosition = PlayerMouse_Behaviour.initialPos; 
                sk.rotationChange(-StartTIme/BreakTime);
                PlayerMouse_Behaviour.stopMovement(true);
                //changement de camera apres la première mort
                if (firstDeath && cameraFollow)
                {
                    Camera.main.gameObject.SetActive(false);
                    cameraFollow.gameObject.SetActive(true);
                    firstDeath = false;
                }  
                PlayAudio_Behaviour.resetMusique(PlayerMouse_Behaviour.resetAudio);       
            }  
        }
        

        // Slider
        timerSlider.value = CurrentTime;
        fillImage.color = newColour;
    }
}
