using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class EventManager
{

    private static Dictionary<EventType, System.Action> eventDictionary = new Dictionary<EventType, System.Action>();

    public static void AddListener(EventType eventType, System.Action function)
    {
        if (!eventDictionary.ContainsKey(eventType))
        {
            eventDictionary.Add(eventType, null);
        }
        eventDictionary[eventType] += function;
    }

    public static void RemoveListener(EventType eventType, System.Action function)
    {
        if(eventDictionary.ContainsKey(eventType) && eventDictionary[eventType] != null)
        {
            eventDictionary[eventType] -= function;
        }
    }

    public static void InvokeEvent(EventType eventType)
    {
        eventDictionary[eventType]?.Invoke();
    }

}
