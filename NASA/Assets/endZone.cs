using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endZone : Ability
{
    public string endZoneTag = "endZone";

    public GameEngine gameEngine;

    private void Start()
    {
        gameObject.tag = endZoneTag;
    }

    public override void ListenerEventHandler(Collider other) 
    {
        if 
            (other.gameObject.CompareTag (endZoneTag))
        {
            Debug.Log("TOTO");
            gameEngine.endGame();
        }
    }
}
