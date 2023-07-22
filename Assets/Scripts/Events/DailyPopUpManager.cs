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

    public Button nextButton;

    public PauseController pauseController;

    private List<Event> eventList;
    private int currentEventIndex = 0;

    [SerializeField] private Image speechBubble;
    [SerializeField] private Image thoughtBubble;

    [SerializeField] private List<Sprite> speechBubbles = new List<Sprite>();
    [SerializeField] private List<Sprite> thoughtBubbles = new List<Sprite>();

    private void Start()
    {
        nextButton.onClick.AddListener(ShowNextEvent);
    }

    public void SetEventList(List<Event> events)
    {
        gameObject.SetActive(true);
        pauseController.MenulessPause();
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

                thoughtBubble.sprite = thoughtBubbles[UnityEngine.Random.Range(0, thoughtBubbles.Count)];
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

                //characterSprite.SetNativeSize();

                speechBubble.sprite = speechBubbles[UnityEngine.Random.Range(0, speechBubbles.Count)];
                thoughtBubble.sprite = thoughtBubbles[UnityEngine.Random.Range(0, thoughtBubbles.Count)];
            }
        }
        else
        {
            gameObject.SetActive(false);
            pauseController.MenulessResume();
        }
    }

    private void ShowNextEvent()
    {
        currentEventIndex++;
        ShowEvent(currentEventIndex);
    }

}