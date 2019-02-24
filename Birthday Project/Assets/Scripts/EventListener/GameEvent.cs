using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        readonly List<GameEventListener> eventListeners = new List<GameEventListener>(); 


        public void Raise()
        {
            // iterates through list in reverse order, so it's safe for the listener to "self-destruct"
            for (int i = eventListeners.Count - 1; i >= 0; --i) eventListeners[i].OnEventRaised();
        }


        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener)) eventListeners.Add(listener);
        }


        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener)) eventListeners.Remove(listener);
        }
    }
}