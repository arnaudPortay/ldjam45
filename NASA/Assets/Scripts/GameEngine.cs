using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public GameObject player;
    public GameObject bootScreen;

    public Mouse_Behaviour mouseBehaviour;

    private CameraEffect cameraEffect;

    private Material blurMaterial;

    public float blurInitValue = 0.10f;

    public float blurDecrementStep = 0.01f;

    private bool isInit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (player)
        {
            player.SetActive(false);
        }

        cameraEffect = Camera.main.GetComponent<CameraEffect>();

        if
            (cameraEffect)
        {
            blurMaterial = cameraEffect.postprocessMaterial;  
        }
         
    }

    void initGame()
    {
        if (player)
        {
            player.SetActive(true);
            isInit = true;
        }
    }

    public void endGame()
    {
        mouseBehaviour.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bootScreen.activeSelf && !isInit)
        {
            if
                (blurMaterial && cameraEffect)
            {
                blurMaterial.SetFloat ("_BlurSize", blurInitValue);
                cameraEffect.enabled = true;
            }
            
            initGame();
        }

        if
            (isInit && cameraEffect && blurMaterial && cameraEffect.enabled)
        {
            if
                (blurMaterial.GetFloat ("_BlurSize") > 0)
            {
                if
                    (blurMaterial.GetFloat ("_BlurSize") - blurDecrementStep > 0)
                {
                    blurMaterial.SetFloat ("_BlurSize", blurMaterial.GetFloat ("_BlurSize") - blurDecrementStep);
                }
                else
                {
                    blurMaterial.SetFloat ("_BlurSize", 0f);
                    cameraEffect.enabled = false;
                }
                
            }
        }
    }
}
