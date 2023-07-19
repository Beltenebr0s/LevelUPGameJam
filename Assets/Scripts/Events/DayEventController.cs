using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayEventController : MonoBehaviour
{

    [SerializeField] private List<Day> days = new List<Day>();
    private int dayCounter = 0;
    [SerializeField] private TMP_Text taskList;
    [SerializeField] private TMP_Text clock;

    public Day currentDay;

    private float timeCounter = 0f;
    private float timeToHour = 3;
    private string minutes = ":00";


    void Start()
    {
        NextDay();
        UpdateClock();
    }

    void Update()
    {
        CheckCompleteTasks();
        UpdateClock();
        UpdateTimer();
    }

    private void CheckCompleteTasks()
    {
        if ( currentDay.AreAllTasksComplete() )
        {
            NextDay();
        }
    }

    private void UpdateTimer()
    {
        timeCounter += Time.deltaTime;
        if ( timeCounter >= timeToHour )
        {
            currentDay.PassTime();
            timeCounter = 0f;
        }
        
        if (currentDay.IsDayOver())
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        if ( days.Count > 0)
        {
            currentDay = days[0];
            days.RemoveAt(0);
            dayCounter++;
            Debug.Log("Día: " + dayCounter);
            // ShowDayPopUps();
            WriteDayTasks();
        }
        else
        {
            Debug.Log("Se ha acabado el juego :)");
        }
    }

    private void WriteDayTasks()
    {
        string taskListText = "";
        foreach(Event ev in currentDay.GetDailyEvents())
        {
            taskListText += "- " + ev.GetTaskName() + "\n";
        }
        taskList.text = taskListText;
    }

    private void UpdateClock()
    {
        if (timeCounter > 1.5)
        { minutes = ":30"; }
        else 
        { minutes = ":00"; }
        clock.text = (currentDay.currentHour + 8).ToString() + minutes;
    }

}
