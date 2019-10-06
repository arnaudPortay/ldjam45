using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public GameObject player;
    
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
