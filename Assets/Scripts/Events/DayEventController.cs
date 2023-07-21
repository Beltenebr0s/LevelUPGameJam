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

    public DailyPopUpManager eventPopup;

    private float timeCounter = 0f;
    private float timeToHour = 3;
    private string minutes = ":00";

    void Update()
    {
        if (GameManager.Instance.gameRunning)
        {
            CheckCompleteTasks();
            UpdateClock();
            UpdateTimer();
        }
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

    public void NextDay()
    {
        CheckDayResults();
        if ( days.Count > 0)
        {
            currentDay = days[0];
            currentDay.SetUpEvents();
            days.RemoveAt(0);
            dayCounter++;
            Debug.Log("Día: " + dayCounter);
            WriteDayTasks();
        }
        if (days.Count <= 0)
        {
            Debug.Log("Acabao");
            GameManager.Instance.EndGame();
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

    private void CheckDayResults()
    {
        int numEventsFinished = 0;
        bool badEnding = false;
        Event.StoryLine badEndingCause = Event.StoryLine.DEFAULT;
        
        foreach ( Event ev in currentDay.GetDailyEvents() )
        {
            if(ev.IsFinished())
            {
                numEventsFinished++;
                if(!ev.IsGoodEvent())
                {
                    badEnding = true;
                    badEndingCause = ev.GetStoryLine();
                    break;
                }
            }
        }
        if(badEnding)
        {
            GameManager.Instance.GameOver(badEndingCause);
        }
        //Debug.Log("Total eventos completados en el día " + dayCounter + ": " + numEventsFinished);
        GameManager.Instance.totalGoodEventsFinished += numEventsFinished;
        GameManager.Instance.FinishDay();
    }

    public void ShowDayPopUps()
    {
        Debug.Log("aaaaaaaaaaaaaaa");
        eventPopup.SetEventList(currentDay.GetDailyEvents());
    }
}
