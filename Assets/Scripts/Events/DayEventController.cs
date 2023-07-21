using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayEventController : MonoBehaviour
{

    [SerializeField] private List<Day> days = new List<Day>();
    private int dayCounter = 0;
    [SerializeField] private TMP_Text clock;

    public Day currentDay;

    public DailyPopUpManager eventPopup;
    public ListaDeEventos checklist;

    private float timeCounter = 0f;
    private float timeToHour = 10;
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
            GameManager.Instance.FinishDay();
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
            GameManager.Instance.FinishDay();
        }
    }

    public void PlayDay(int numDay)
    {
        Debug.Log("Día: " + numDay);
        currentDay = days[numDay];
        currentDay.SetUpEvents();
        ShowDayPopUps();
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
        GameManager.Instance.totalGoodEventsFinished += numEventsFinished;
        GameManager.Instance.FinishDay();
    }

    public void ShowDayPopUps()
    {
        checklist.SetEventList(currentDay.GetDailyEvents());
        eventPopup.SetEventList(currentDay.GetDailyEvents());
    }
}
