using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using JetBrains.Annotations;

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
        mainMenu.transform.Find("Start Btn").gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
        mainMenu.transform.Find("Settings Btn").gameObject.GetComponent<Button>().onClick.AddListener(OpenSettings);
        mainMenu.transform.Find("Quit Btn").gameObject.GetComponent<Button>().onClick.AddListener(QuitGame);

        pauseMenu.transform.Find("Resume Btn").gameObject.GetComponent<Button>().onClick.AddListener(pauseController.Resume);
        pauseMenu.transform.Find("Settings Btn").gameObject.GetComponent<Button>().onClick.AddListener(OpenSettings);
        pauseMenu.transform.Find("Exit Btn").gameObject.GetComponent<Button>().onClick.AddListener(OpenMainMenu);

        settingsMenu.transform.Find("Back Btn").gameObject.GetComponent<Button>().onClick.AddListener(CloseSettings);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    
    public AudioMixer audiomixer;
    public AudioMixer musicmixer;
    public AudioMixer effectmixer;
    public void SetMainVolume(float volume)
    {

        audiomixer.SetFloat("mastervolume", volume);
    }public void SetMusicVolume(float volume)
    {

        musicmixer.SetFloat("musicvolume", volume);
    }public void SetEffectVolume(float volume)
    {

        effectmixer.SetFloat("effectvolume", volume);
    }

    public GameObject BeaAnimated;
    public void QuitaDeAhi()
    {
        BeaAnimated.transform.position = new Vector3(2622, -1519, 0);
    }
    public void Vuelveahi()
    {
        BeaAnimated.transform.position = new Vector3(534, -1519, 0);
    }

}
