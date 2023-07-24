using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DayEventController eventController;
    [SerializeField] private GameObject gameOverUIPanel;
    [SerializeField] private TMP_Text endingText;
    [SerializeField] private RawImage backgroundCanvas;
    [SerializeField] private Texture defaultBackground;

    [TextAreaAttribute(5, 2)]
    [SerializeField] private string phisingBadEnding;

    [TextAreaAttribute(5, 2)]
    [SerializeField] private string bustedBadEnding;

    [TextAreaAttribute(5, 2)]
    [SerializeField] private string waterBadEnding;

    [TextAreaAttribute(5, 2)]
    [SerializeField] private string notEnoughBadEnding;

    [TextAreaAttribute(5, 2)]
    [SerializeField] private string notWorkingBadEnding;

    [TextAreaAttribute(5, 2)]
    [SerializeField] private string defaultGoodEnding;

    public GameObject transitionPanel;
    public bool isFirstDay = true;

    public GameObject player;
    public Transform startingPosition;

    public bool gameRunning;
    public float startDayTimer = 1.5f;
    public float startDayTimerCount = 0f;
    public int totalGoodEventsFinished;
    public int requiredGoodEvents;

    private int currentDay = 0;

    public Image endImage;
    public Sprite goodEndingSprite;
    public Sprite badEndingSprite;


    public static GameManager Instance { get; private set ;}
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    void Start()
    {
        RestartGame();
    }

    void Update()
    {
        if(!gameRunning)
        {
            if(startDayTimerCount >= startDayTimer)
            {
                if(isFirstDay)
                {
                    isFirstDay = false;
                    eventController.PlayDay(0);
                }
                gameRunning = true;
                StartCoroutine(TransitionFadeOut());
                startDayTimerCount = 0f;
                eventController.PlayDay(currentDay);
            }
            startDayTimerCount += Time.deltaTime;
        }
    }

    public void RestartGame()
    {
        player.transform.position = startingPosition.position;
        Time.timeScale = 1f;
        isFirstDay = true;
        gameRunning = false;
        transitionPanel.SetActive(true);
        transitionPanel.GetComponent<RawImage>().CrossFadeAlpha(1f, 0f, true);
        gameOverUIPanel.SetActive(false);
        totalGoodEventsFinished = 0;
        startDayTimerCount = 0f;
        requiredGoodEvents = 14;
        currentDay = 0;
        eventController.RestartDays();
    }

    public void EndGame()
    {
        StartCoroutine(TransitionFadeOut());
        Time.timeScale = 0f;
        if(totalGoodEventsFinished < requiredGoodEvents)
        {
            GameOver(Event.StoryLine.NOT_ENOUGH_GOOD_EVENTS);
        }
        else
        {
            endImage.sprite = goodEndingSprite;
            endingText.SetText(defaultGoodEnding);
        }
    }

    public void GameOver(Event.StoryLine causeOfEnding)
    {
        string ending = "";
        switch (causeOfEnding)
        {
            case Event.StoryLine.PHISING:
            {
                ending = phisingBadEnding;
                break;
            }
            case Event.StoryLine.WATER:
            {
                ending = waterBadEnding;
                break;
            }
            case Event.StoryLine.BUSTED:
            {
                ending = bustedBadEnding;
                break;
            }
            case Event.StoryLine.NOT_ENOUGH_GOOD_EVENTS:
            {
                ending = notEnoughBadEnding;
                break;
            }
            default:
            {
                ending = notEnoughBadEnding;
                break;
            }
        }
        endImage.sprite = badEndingSprite;
        endingText.SetText(ending);
        gameOverUIPanel.SetActive(true);
    }

    public void FinishDay()
    {
        CheckDayResults();
        currentDay++;
        StartCoroutine(TransitionFadeIn());
        StartCoroutine(PlayerTeleport());
        gameRunning = false;
        startDayTimerCount = 0f;
        eventController.currentDay.TearDownEvents();
        if(currentDay > 2 )
        {
            EndGame();
        }
    }

    private void CheckDayResults()
    {
        int numEventsFinished = 0;
        bool badEnding = false;
        Event.StoryLine badEndingCause = Event.StoryLine.DEFAULT;
        
        foreach ( Event ev in eventController.currentDay.GetDailyEvents() )
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
        else
        {
            totalGoodEventsFinished += numEventsFinished;
        }
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerCaught()
    {
        endImage.sprite = badEndingSprite;
        endingText.SetText(notWorkingBadEnding);
        gameOverUIPanel.SetActive(true);
    }

    private IEnumerator TransitionFadeIn()
    {
        
        transitionPanel.SetActive(true);
        transitionPanel.GetComponent<RawImage>().CrossFadeAlpha(0f, 0f, true);
        transitionPanel.GetComponent<RawImage>().CrossFadeAlpha(1f, 1f, true);
        yield return new WaitForSecondsRealtime(1);

    }

    private IEnumerator TransitionFadeOut()
    {
        transitionPanel.SetActive(true);
        transitionPanel.GetComponent<RawImage>().CrossFadeAlpha(1f, 0f, true);
        transitionPanel.GetComponent<RawImage>().CrossFadeAlpha(0f, 1f, true);
        yield return new WaitForSecondsRealtime(1);
        transitionPanel.SetActive(false);
    }

    private IEnumerator PlayerTeleport()
    {
        yield return new WaitForSecondsRealtime(1);
        player.transform.position = startingPosition.position;
        backgroundCanvas.texture = defaultBackground;
    }
}
