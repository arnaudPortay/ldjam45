using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public GameObject player;
    public GameObject bootScreen;

    public Mouse_Behaviour mouseBehaviour;

    private bool isInit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (player)
        {
            player.SetActive(false);
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
            initGame();
        }
    }
}
