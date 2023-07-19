using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DailyPopUpManager : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Button nextButton;
    public SpriteRenderer EventSprite;
    public TMP_Text playerThoughts;

    public PauseController pauseController;

    private List<Event> eventList;
    private int currentEventIndex = 0;

    private void Start()
    {
        nextButton.onClick.AddListener(ShowNextEvent);
    }

    public void SetEventList(List<Event> events)
    {
        gameObject.SetActive(true);
        pauseController.PauseToogle();
        eventList = events;
        currentEventIndex = 0;
        ShowEvent(currentEventIndex);
    }

    private void ShowEvent(int index)
    {
        if (index >= 0 && index < eventList.Count)
        {
            Event currentEvent = eventList[index];
            titleText.text = currentEvent.eventTitle;
            descriptionText.text = currentEvent.description;
            EventSprite.sprite = currentEvent.characterSprite.sprite;
            playerThoughts.text = currentEvent.playerThoughts;
        }
        else
        {
            gameObject.SetActive(false);
            pauseController.PauseToogle();
        }
    }

    private void ShowNextEvent()
    {
        currentEventIndex++;
        ShowEvent(currentEventIndex);
    }
}