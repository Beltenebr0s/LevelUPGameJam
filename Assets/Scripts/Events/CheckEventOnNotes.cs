using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ListaDeEventos : MonoBehaviour
{
    private List<Event> events = new List<Event> ();

    private void Update()
    {
        EventFinished();
    }


    // Llamado cuando un evento cambia su estado eventFinished
    public void EventFinished()
    {
        Debug.Log("Checking events");
        for (int i = 0; i < events.Count; i++)
        {
            Debug.Log(i);
            if (events[i]!=null)
            {
                transform.GetChild(i).GetChild(0).gameObject.SetActive(events[i].eventFinished);
            }
        }
        Debug.Log("Check list update");
    }

    public void SetEventList(List<Event> eventList)
    {
        events = eventList;
        WriteDayTasks();
    }

    private void WriteDayTasks()
    {
        for (int i= 0; i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        
         for (int i = 0; i < events.Count; i++)
         {
            if (events[i] != null)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
                transform.GetChild(i).gameObject.GetComponentInChildren<TMP_Text>().text = events[i].GetTaskName();
            }
         }
         EventFinished();
    }
}

