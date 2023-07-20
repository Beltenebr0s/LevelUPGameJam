using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PauseController pauseController;

    [SerializeField] private bool mainMenuIsOpen = false;
    [SerializeField] private bool pauseMenuIsOpen = false;


    void Start()
    {
        for (int i = 0; i < mainMenu.transform.childCount; i++) 
        {
            if (mainMenu.transform.GetChild(i).gameObject.name == "Start Btn")
            {
                mainMenu.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
            }
            else if (mainMenu.transform.GetChild(i).gameObject.name == "Settings Btn")
            {
                mainMenu.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(OpenSettings);
            }
            else if (mainMenu.transform.GetChild(i).gameObject.name == "Quit Btn")
            {
                mainMenu.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(QuitGame);
            }
        }

        for (int i = 0; i < pauseMenu.transform.childCount; i++)
        {
            if (pauseMenu.transform.GetChild(i).gameObject.name == "Resume Btn")
            {
                pauseMenu.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(pauseController.Resume);
            }
            else if (pauseMenu.transform.GetChild(i).gameObject.name == "Settings Btn")
            {
                pauseMenu.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(OpenSettings);
            }
            else if (pauseMenu.transform.GetChild(i).gameObject.name == "Exit Btn")
            {
                pauseMenu.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(OpenMainMenu);
            }
        }

        for (int i = 0; i < settingsMenu.transform.childCount; i++)
        {
            if (settingsMenu.transform.GetChild(i).gameObject.name == "Back Btn")
            {
                settingsMenu.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(CloseSettings);
            }
        }
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsMenu.activeSelf)
            {
                CloseSettings();
            }
            else if (pauseController.gameIsPaused)
            {
                pauseController.Resume();
            }
            else
            {
                pauseController.Pause();
            }
        }
    }

    public void StartGame()
    {
        //Game starts
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        mainMenuIsOpen = mainMenu.activeSelf;
        pauseMenuIsOpen = pauseMenu.activeSelf;
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void CloseSettings() 
    { 
        settingsMenu.SetActive(false);
        mainMenu.SetActive(mainMenuIsOpen);
        pauseMenu.SetActive(pauseMenuIsOpen);
    }

    public void OpenMainMenu() 
    { 
        mainMenu.SetActive(true); 
    }

    public void CloseMainMenu()
    {
        mainMenu.SetActive(false);
    }
}
