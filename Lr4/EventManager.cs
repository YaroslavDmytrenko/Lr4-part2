using System;
using System.Collections.Generic;
using System.Threading;

public delegate void EventHandler(object sender, EventArgs args);

public class EventManager
{
    private Dictionary<string, List<EventHandler>> eventHandlers;
    private Timer timer;
    private int intervalMilliseconds;

    public EventManager(int intervalMilliseconds)
    {
        eventHandlers = new Dictionary<string, List<EventHandler>>();
        timer = new Timer(OnTimerElapsed, null, Timeout.Infinite, Timeout.Infinite);
        this.intervalMilliseconds = intervalMilliseconds;
    }

    public void AddEventHandler(string eventName, EventHandler handler)
    {
        if (!eventHandlers.ContainsKey(eventName))
        {
            eventHandlers[eventName] = new List<EventHandler>();
        }

        eventHandlers[eventName].Add(handler);
    }

    public void RemoveEventHandler(string eventName, EventHandler handler)
    {
        if (eventHandlers.ContainsKey(eventName))
        {
            eventHandlers[eventName].Remove(handler);
        }
    }

    public void PublishEvent(string eventName, EventArgs args)
    {
        if (eventHandlers.ContainsKey(eventName))
        {
            timer.Change(intervalMilliseconds, Timeout.Infinite);

            foreach (EventHandler handler in eventHandlers[eventName])
            {
                handler?.Invoke(this, args);
            }
        }
    }

    private void OnTimerElapsed(object state)
    {
        timer.Change(Timeout.Infinite, Timeout.Infinite);
    }
}