using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventSystem : MonoBehaviour
{
    public List<Ability> listeners;
    // Start is called before the first frame update
    
    void Start()
    {
        listeners = new List<Ability>();
    }
    public void registerListener (Ability e)
    {
        if (!listeners.Contains(e))
        {
            listeners.Add(e); 
        }
    }

   public void unregisterListener (Ability e)
    {
        listeners.Remove(e);
    }

    void OnTriggerEnter(Collider other) 
    {
        foreach (Ability e in listeners)
        {
            //print(" triggering : " + e.name);
            e.ListenerEventHandler(other);
        }
    }
}
