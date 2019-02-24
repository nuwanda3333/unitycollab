using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event the listener is registered with")]
        public GameEvent gameEvent;

        [Tooltip("This response is invoked when event is raised")]
        public UnityEvent response;


        public void OnEventRaised() { response.Invoke(); }


        void OnEnable() { gameEvent.RegisterListener(this); }

        void OnDisable() { gameEvent.UnregisterListener(this); }


    }
}