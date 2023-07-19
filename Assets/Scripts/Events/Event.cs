using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Event
{
    public enum StoryLine
    {
        ARBOLITO,
        OBRAS,
        REUNION,
        PRINCIPE,
        DEFAULT,
        BUSTED
    }

    [SerializeField] public string eventTitle;

    [SerializeField] private StoryLine storyLine;

    [TextAreaAttribute(10, 3)]
    [SerializeField] public string description;

    [SerializeField] public SpriteRenderer characterSprite;

    [SerializeField] public string playerThoughts;

    [SerializeField] private List<GameObject> interactableObjects;
    [SerializeField] private bool goodDecision = true;
    [SerializeField] private string taskName;
    
    public bool eventFinished = false;

    public void SetUp()
    {
        foreach (GameObject item in interactableObjects)
        {
            item.GetComponent<Trigger>().enabled = true;
            item.GetComponent<Trigger>().SetAssociatedEvent(this);
        }
    }

    public bool IsFinished()
    {
        return eventFinished;
    }

    public string GetTaskName()
    {
        return taskName;
    }

    public override string ToString()
    {
        return this.eventTitle;
    }

    public void CompleteEvent()
    {
        eventFinished = true;
    }

    public bool IsGoodEvent()
    {
        return goodDecision;
    }

    public StoryLine GetStoryLine()
    {
        return storyLine;
    }

}
