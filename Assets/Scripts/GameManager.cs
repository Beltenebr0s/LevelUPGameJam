using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUIPanel;
    [SerializeField] private TMP_Text endingText;
    
    [TextAreaAttribute(5, 2)]
    [SerializeField] private string phisingBadEnding;

    [TextAreaAttribute(5, 2)]
    [SerializeField] private string bustedBadEnding;

    [TextAreaAttribute(5, 2)]
    [SerializeField] private string waterBadEnding;

    [TextAreaAttribute(5, 2)]
    [SerializeField] private string notEnoughBadEnding;

    [TextAreaAttribute(5, 2)]
    [SerializeField] private string defaultGoodEnding;


    public bool gameRunning;
    public float startDayTimer = 3f;
    public float startDayTimerCount = 0f;
    public int totalGoodEventsFinished;
    public int requiredGoodEvents;

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
            startDayTimerCount += Time.deltaTime;
            if(startDayTimerCount >= startDayTimer)
            {
                gameRunning = true;
                startDayTimerCount = 0f;
            }
        }
    }

    public void RestartGame()
    {
        gameOverUIPanel.SetActive(false);
        totalGoodEventsFinished = 0;
        requiredGoodEvents = 14;
    }

    public void EndGame()
    {
        Debug.Log("------------------------------------");
        Debug.Log("Eventos completados: " + totalGoodEventsFinished);
        Debug.Log("Eventos necesarios: " + requiredGoodEvents);
        if(totalGoodEventsFinished < requiredGoodEvents)
        {
            GameOver(Event.StoryLine.NOT_ENOUGH_GOOD_EVENTS);
        }
        else
        {
            Debug.Log("Buen ending");
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
        endingText.SetText(ending);
        gameOverUIPanel.SetActive(true);
    }

    public void FinishDay()
    {
        gameRunning = false;
    }
}
