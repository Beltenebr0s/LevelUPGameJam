using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Event
{
    [SerializeField] private string eventTitle;

    [TextAreaAttribute(10, 3)]
    [SerializeField] private string description;

    [SerializeField] private string playerThoughts;

    [SerializeField] private List<GameObject> interactableObjects;
    [SerializeField] private bool goodDecision = true;
    [SerializeField] private string taskName;
    
    private bool eventFinished = false;

    // public void SetUp()
    // {
    //     // TODO: añadir el script de interacción a los objetos que toquen
            // foreach (GameObject item in interactableObjects)
            // {
            //     item.AddComponent<Interaccion>();
            // }
    // }

    public bool IsFinished()
    {
        return eventFinished;
    }

    public string GetTaskName()
    {
        return taskName;
    }

}
