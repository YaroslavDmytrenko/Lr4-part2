using System;
using System.Collections.Generic;

public class Publisher
{
    private Dictionary<int, List<Action>> subscribers;

    public Publisher()
    {
        subscribers = new Dictionary<int, List<Action>>();
    }

    public void Publish(int priority)
    {
        if (subscribers.ContainsKey(priority))
        {
            foreach (Action subscriber in subscribers[priority])
            {
                subscriber?.Invoke();
            }
        }
    }

    public void Subscribe(int priority, Action subscriber)
    {
        if (!subscribers.ContainsKey(priority))
        {
            subscribers[priority] = new List<Action>();
        }

        subscribers[priority].Add(subscriber);
    }

    public void Unsubscribe(int priority, Action subscriber)
    {
        if (subscribers.ContainsKey(priority))
        {
            subscribers[priority].Remove(subscriber);
        }
    }
}