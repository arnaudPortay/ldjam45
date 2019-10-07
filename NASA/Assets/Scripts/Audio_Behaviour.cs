using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Behaviour : MonoBehaviour
{
    public AudioSource mAudioSource;
    public AudioSource Audio_MainMenu;
    public AudioSource Audio_Vision;   
    public AudioSource Audio_Toucher;      
    public AudioSource Audio_Motrice;
    public AudioSource Audio_Audition_Sentiments;
    public AudioSource Audio_Item;
    public AudioClip impact;
    private bool exit = false;
    public bool timerOut = false;

    public float lowered = 0.5f;
    public float mainVolume =1.0f;
    float wait =0;


    // Start is called before the first frame update
    void Start()
    {
        mAudioSource = Audio_MainMenu;
        Audio_MainMenu.Play();
        Audio_MainMenu.Pause();
        Audio_Vision.Play();
        Audio_Vision.Pause();
        Audio_Toucher.Play();
        Audio_Toucher.Pause();
        Audio_Motrice.Play();
        Audio_Motrice.Pause();
        Audio_Audition_Sentiments.Play();
        Audio_Audition_Sentiments.Pause();
        Audio_Item.Pause();

        startMusique();
    }
    public void startMusique()
    {
        mAudioSource.Play();
    }

    public void stopMusique() 
    {
        mAudioSource.Pause();
    }
    public void resetMusique(AudioSource source)
    {
        mAudioSource.Pause();
        mAudioSource = source;
        mAudioSource.UnPause();
    }

    // Update is called once per frame
    protected void  FixedUpdate()
    {
        if (wait >0)
        {
            wait -= Time.fixedDeltaTime;
            if (wait <= 0)
            {
                mAudioSource.volume = mainVolume;
            }
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

            mAudioSource.Pause();
            bool swapOther =mAudioSource == Audio_MainMenu;
            
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
            if (!swapOther)
            {
                mAudioSource = Audio_MainMenu;
            }
            mAudioSource.volume = mainVolume;
            mAudioSource.UnPause();

            exit = false;
        }
    }

    public void itemSound()
    {
        mAudioSource.volume = lowered*mainVolume;
        Audio_Item.PlayOneShot(impact, mainVolume);
        wait = impact.length;
    } 
}
