using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class Day 
{
    [SerializeField] private List<Event> events;


    private int hoursPerDay;
    public int currentHour;

    public Day ()
    {
        events = new List<Event>();
        currentHour = 0;
        hoursPerDay = 10;
    }

    public void PassTime()
    {
        currentHour += 1;
    }

    public bool IsDayOver()
    {
        return currentHour >= hoursPerDay || AreEventsFinished();
    }

    public bool AreAllTasksComplete()
    {
        return events.Count == 0;
    }

    public bool AreEventsFinished()
    {
        int numFinishedEvents = 0;
        foreach (Event ev in events)
        {
            if (ev.IsFinished())
            {
                numFinishedEvents++;
            }
        }
        return numFinishedEvents == events.Count;
    }

    public List<Event> GetDailyEvents()
    {
        return events;
    }

}
