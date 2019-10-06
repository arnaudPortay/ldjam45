using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Behaviour : MonoBehaviour
{
    private AudioSource mAudioSource;
    public AudioSource Audio_MainMenu;
    public AudioSource Audio_Vision;   
    public AudioSource Audio_Toucher;      
    public AudioSource Audio_Motrice;
    public AudioSource Audio_Audition_Sentiments;
    private bool exit = false;
    public bool timerOut = false;


    // Start is called before the first frame update
    void Start()
    {
        Audio_MainMenu.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOut)
        {
            Audio_Vision.Stop();
            Audio_Toucher.Stop();      
            Audio_Motrice.Stop();
            Audio_Audition_Sentiments.Stop();
            Audio_MainMenu.Play();
            timerOut = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        exit = true;
    }
    void OnTriggerEnter(Collider other) 
    {

        if 
            (other.gameObject.CompareTag ("Musique") && exit)
        {

            Audio_Vision.Stop();
            Audio_Toucher.Stop();      
            Audio_Motrice.Stop();
            Audio_Audition_Sentiments.Stop();

            switch (other.gameObject.name)
            {
                case "Zone 1 Cervelet":               
                    mAudioSource = Audio_MainMenu;
                break;
                case "Zone 2 Vision":
                    mAudioSource = Audio_Vision;
                break;
                case "Zone 3 Toucher":
                    mAudioSource = Audio_Toucher;
                break;
                case "Zone 4 Motrice":
                    mAudioSource = Audio_Motrice;
                break;
                case "Zone 5 Sentiments":
                    mAudioSource = Audio_Audition_Sentiments;
                break;
                case "Zone 6 Audition":
                    mAudioSource = Audio_Audition_Sentiments;
                break;
            default:
                    mAudioSource = Audio_MainMenu;
                break;
            }

            if (Audio_MainMenu.isPlaying)
            {
                Audio_MainMenu.Stop();
                mAudioSource.Play();
            }
            else
            {                
                Audio_MainMenu.Play();
            }
            exit = false;
        }
    }
}
