using UnityEngine.Events;
using System.Collections.Generic;

namespace Patterns.EventBus
{
    public enum RaceEventType
    {
        COUNTDOWN,
        START,
        RESTART,
        PAUSE,
        STOP,
        FINISH,
        QUIT
    }

    public class RaceEventBus
    {
        private static readonly IDictionary<RaceEventType, UnityEvent> Events = new Dictionary<RaceEventType, UnityEvent>();

        public static void Subscribe(RaceEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(eventType, out thisEvent))
            { // 있으면
                thisEvent.AddListener(listener);
            }
            else
            { // 없으면
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(eventType, thisEvent);
            }
        }

        public static void Unsubscribe(RaceEventType type, UnityAction listener)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(type, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Publish(RaceEventType type)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(type, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }


    // TODO : p60 레이스 이벤트 버스 테스트 코드 작성 할 것
}