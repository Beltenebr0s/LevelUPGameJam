using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DailyPopUpManager : MonoBehaviour
{

    public GameObject eventDescriptionObject;

    public TMP_Text descriptionText;
    public Image characterSprite;

    public Image playerSprite;
    public TMP_Text playerThoughts;

    public TMP_Text buttonText;
    public Button nextButton;

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
        Time.timeScale = 0f;
        eventList = events;
        currentEventIndex = 0;
        ShowEvent(currentEventIndex);
    }

    private void ShowEvent(int index)
    {
        if (index >= 0 && index < eventList.Count)
        {
            Event currentEvent = eventList[index];
            if(currentEvent.description.Equals(""))
            {
                // Just a player thought
                descriptionText.text = "";
                eventDescriptionObject.SetActive(false);
                characterSprite.gameObject.SetActive(false);
                playerThoughts.text = currentEvent.playerThoughts;
                playerSprite.sprite = currentEvent.playerSprite;
                buttonText.text = currentEvent.buttonText;
            }
            else
            {
                // Other gives the event
                descriptionText.text = currentEvent.description;
                eventDescriptionObject.SetActive(true);
                characterSprite.gameObject.SetActive(true);
                characterSprite.sprite = currentEvent.characterSprite;
                playerThoughts.text = currentEvent.playerThoughts;
                playerSprite.sprite = currentEvent.playerSprite;
                buttonText.text = currentEvent.buttonText;
            }
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void ShowNextEvent()
    {
        currentEventIndex++;
        ShowEvent(currentEventIndex);
    }
}