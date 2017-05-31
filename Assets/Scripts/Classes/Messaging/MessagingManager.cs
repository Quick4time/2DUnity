using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MessagingManager : MonoBehaviour {

    // Static singletone property
    public static MessagingManager Instance { get; private set;}

    // Public property for manager
    private List<Action> subscribers = new List<Action>();

    private void Awake()
    {
        Debug.Log("Messaging Manager Started");
        // First we check if there are any other instances conflicting
        if (Instance != null && Instance != this)
        {
            // Destroy other instances if it not the same
            Destroy(gameObject);
        }
        // Save our current singletone instance
        Instance = this;
        // Make sure that the instance is not destroyed between scenes (this is optional).
        DontDestroyOnLoad(this);
    }
    // Subscribe method for manager
    public void Subscribe(Action subscriber)
    {
        if (subscribers != null)
        {
            subscribers.Add(subscriber);
        }
    }
    // Unsubscribe method for manager
    public void UnSubscribe(Action subscriber)
    {
        if (subscribers != null)
        {
            subscribers.Remove(subscriber);
        }
    }
    // Clear subscribers method for manager
    public void ClearAllSubscribers()
    {
        if (subscribers != null)
        {
            subscribers.Clear();
        }
    }
    public void Broadcast()
    {
        if (subscribers != null)
        {
            Debug.Log("Broadcast requested, No of Subscribers = " + subscribers.Count);
            foreach (var subscriber in subscribers.ToArray())
            {
                subscriber();
            }
        }
    }
}
