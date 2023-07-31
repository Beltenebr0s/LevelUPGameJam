using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayEventController : MonoBehaviour
{

    [SerializeField] private List<Day> days = new List<Day>();
    [SerializeField] private TMP_Text clock;

    public Day currentDay;

    public DailyPopUpManager eventPopup;
    public ListaDeEventos checklist;

    public float timeCounter = 0f;
    private float timeToHour = 15;
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


    public void ShowDayPopUps()
    {
        checklist.SetEventList(currentDay.GetDailyEvents());
        eventPopup.SetEventList(currentDay.GetDailyEvents());
    }

    public void RestartDays()
    {
        foreach(Day d in days)
        {
            d.currentHour = 0;
            foreach (Event ev in d.GetDailyEvents())
            {
                ev.eventFinished = false;
                ev.TearDown();
            }
        }
    }
}
