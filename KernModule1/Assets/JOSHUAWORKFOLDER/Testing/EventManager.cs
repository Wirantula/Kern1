using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class EventManager
{

    private static Dictionary<EventType, System.Action> _eventDictionary = new Dictionary<EventType, System.Action>();

    public static void AddListener(EventType eventType, System.Action function)
    {
        if (!_eventDictionary.ContainsKey(eventType))
        {
            _eventDictionary.Add(eventType, null);
        }
        _eventDictionary[eventType] += function;
    }

    public static void RemoveListener(EventType eventType, System.Action function)
    {
        if (_eventDictionary.ContainsKey(eventType) && _eventDictionary[eventType] != null)
        {
            _eventDictionary[eventType] -= function;
        }
    }

    public static void InvokeEvent(EventType eventType)
    {
        //eventDictionary[eventType]?.Invoke();
        if(_eventDictionary[eventType] != null)
        {
            _eventDictionary[eventType].Invoke();
        }
    }

}