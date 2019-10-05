using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventSystem : MonoBehaviour
{
    List<Ability> listeners;
    // Start is called before the first frame update
    
    void Start()
    {
        listeners = new List<Ability>();
    }
    void registerListener (Ability e)
    {
        listeners.Add(e);
    }

    void unregisterListener (Ability e)
    {
        listeners.Remove(e);
    }

    void OnTriggerEnter(Collider other) 
    {
        foreach (Ability e in listeners)
        {
            e.ListenerEventHandler(other);
        }
    }
}
