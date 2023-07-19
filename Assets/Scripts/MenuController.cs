using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject pauseMenu;

    private bool mainMenuIsOpen = false;
    private bool pauseMenuIsOpen = false;
    
    void Start()
    {
        
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
