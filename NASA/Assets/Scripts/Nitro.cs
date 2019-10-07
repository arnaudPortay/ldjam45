using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Nitro : Ability
{
    Rigidbody playerRigidbody; 
    public float fastAndFuriousSpeed = 30.0f;
    public float temps = 0;
    public int tempsint = 3;
    public float temps2 = 0;
    public int tempsint2 = 6;
    public Slider nitroSlider; 
    private GameObject test;
    private Color newColour;
    private GameObject fill; 
    private Image fillImage;
    public Text textNitro;

    // Start is called before the first frame update
    void Start()
    {
        test = nitroSlider.transform.gameObject; 
        nitroSlider.maxValue = tempsint;
        fill = nitroSlider.transform.GetChild (1).GetChild (0).gameObject; 
        fillImage = fill.GetComponent<Image> ();
    }

    protected override void InitAbility ()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        playerRigidbody = subject.GetComponent<Rigidbody>();
        TriggerEventSystem triggerEventSystem= subject.GetComponent<TriggerEventSystem>();
        if (triggerEventSystem)
        {
            triggerEventSystem.registerListener (this);
        }
    }

    protected void FixedUpdate ()
    {
        if (!subject)
        {
            return;
        }
        
        if ( !test.activeSelf)
        {
            test.SetActive(true);
            nitroSlider.enabled = true;
            textNitro.enabled = true;
        
        }     
        acceleration();
    }

    private void acceleration()
    {
        // Color Slider part
        newColour = new Color(                                             
                                1f - (nitroSlider.value/nitroSlider.maxValue),     // R - empty
                                nitroSlider.value/nitroSlider.maxValue,            // G - full
                                0f                                       // B - Unused
                            );
        fillImage.color = newColour;   

        bool n = Input.GetKey(KeyCode.N);
        nitroSlider.value = temps;
    
        if (!playerRigidbody)
        {
             playerRigidbody = subject.GetComponent<Rigidbody>();
        }   
        if
            (temps <= 0 && temps2 <=0 && n)
        {
            //début de l'accélération
            playerRigidbody.AddRelativeForce(Vector3.forward * fastAndFuriousSpeed);
            temps = tempsint;
            nitroSlider.value = temps;
            //nitroSlider.enabled = true;
        }
        else if
            (temps > 0 && temps2 <=0 && n)
        {
            //accélération jusqu'à la fin du temps autorisé
            playerRigidbody.AddRelativeForce(Vector3.forward * fastAndFuriousSpeed);
            temps -= Time.fixedDeltaTime;
            if (temps <= 0)
            {
                // Temps maximal autorisé atteint
                temps2 = tempsint2;
            }
        }
        else if
            (temps > 0 && temps <= tempsint && temps2 <=0 && !n)
        {
            // Temps maximal autorisé non atteint mais fin du boost, rechargement rapide
            temps += Time.fixedDeltaTime;     
        }
        else if
            (temps2 > 0)
        {
            // Temps maximal autorisé atteint et fin du boost, rechargement lent
            temps2 -= Time.fixedDeltaTime;
            nitroSlider.value = (tempsint2-temps2)*tempsint/tempsint2;
            // Color Slider part
            newColour = new Color( 0,0,0);
            fillImage.color = newColour;  
        }
        else
        {
            nitroSlider.value = tempsint;   
        }  
    }
}